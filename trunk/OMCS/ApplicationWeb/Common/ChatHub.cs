using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat.Common;
using OMCS.DAL.Model;
using System.Diagnostics;
using OMCS.BLL;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        #region Data Members

        OMCSDBContext _db;
        ConversationBusiness business;
        ChatHubHelper helper;
        
        //Hold all connection for Doctor or Patient
        //One use can have many connection (by open tabs,...)
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        //List of all Doctor and their Status
        static List<DoctorDetail> Doctors = new List<DoctorDetail>();

        #endregion

        public ChatHub()
        {
            _db = new OMCSDBContext();
            business = new ConversationBusiness(_db);
            helper = new ChatHubHelper(_db);
            Doctors = helper.GetListDoctors();
        }

        #region Methods

        public void ConnectDoctor(string email)
        {
            var id = Context.ConnectionId;

            var doctor = _db.Doctors.Where(x=>x.Email.Equals(email)).FirstOrDefault();
            var doctorDetail = Doctors.Where(x => x.Email.Equals(email)).FirstOrDefault();

            helper.UpdateDoctorsStatus(email, Doctors, ConnectedUsers);

            //Add User
            UserDetail userDetail = new UserDetail
            {
                ConnectionId = id,
             //   CountMessageUnRead = business.CountMessageUnRead(doctor),
                ProfilePicture = doctor.ProfilePicture,
                FullName = doctor.FullName,
                Email = doctor.Email,
                OnlineStatus = OnlineStatus.Online
            };

            //Show List of Lastest contact
            var userDetailList = helper.GetLastestConversationList(email, ConnectedUsers);
            userDetail.ConversationList = userDetailList;
            ConnectedUsers.Add(userDetail);

            Debug.WriteLine("Size of userDetailList: " + userDetailList.Count);

            Clients.Caller.onGetConversationList(userDetailList);
            Clients.AllExcept(id).onRefreshDoctorList();
        }

        public void ConnectPatient(string email)
        {
            var id = Context.ConnectionId;
            var userDetail = ConnectedUsers.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (userDetail == null)
            {
                var user = _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
                userDetail = new UserDetail { 
                    ConnectionId = id,
                    CountMessageUnRead = business.CountMessageUnRead(user),
                    Email = email,
                    FullName = user.FullName, ProfilePicture = user.ProfilePicture,
                    OnlineStatus = OnlineStatus.Online
                };
                ConnectedUsers.Add(userDetail);
                userDetail.DoctorList = helper.GetListDoctorConversation(email, ConnectedUsers);
            }
            Clients.Caller.onGetDoctorList(userDetail.DoctorList);
            Clients.Caller.onMessageUnRead(userDetail);

            //Update status for others
            var doctorList = ConnectedUsers.Where(x=>x.ConversationList != null).ToList();
            foreach (UserDetail doctor in doctorList)
            {
                var patient = doctor.ConversationList.Find(x => x.Email == userDetail.Email);
                if (patient != null)
                {
                    patient.OnlineStatus = OnlineStatus.Online;
                }
                Clients.Client(doctor.ConnectionId).onGetConversationList(doctor.ConversationList);
            }
        }

        public void UpdateStatusToBusy(string email)
        {
            var id = Context.ConnectionId;
            var user = Doctors.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                user.OnlineStatus = OnlineStatus.Busy;
            }
            helper.UpdateDoctorsStatus(email, Doctors, ConnectedUsers);
            Clients.AllExcept(id).onRefreshDoctorList();
        }

        public void UpdateStatusToOnline(string email)
        {
            var id = Context.ConnectionId;
            var user = Doctors.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                user.OnlineStatus = OnlineStatus.Online;
            }
            helper.UpdateDoctorsStatus(email, Doctors, ConnectedUsers);
            Clients.AllExcept(id).onRefreshDoctorList();
        }

        public void GetMessageList(string email)
        {
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Email.Equals(fromUserDetail.Email)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            var toUserDetail = ConnectedUsers.Where(x => x.Email.Equals(email)).FirstOrDefault();

            //Check if toUserDetail is not online yet
            if (toUserDetail == null)
            {
                toUserDetail = helper.ConvertUserToUserDetail(toUser);
            }
            List<MessageDetail> userDetails = helper.GetMessageDetail(fromUser.Email, toUser.Email);
            Clients.Caller.onGetMessageList(fromUserDetail, toUserDetail, userDetails);
            
        }

        public void SendMessageTo(string toEmail, string message)
        {
            business = new ConversationBusiness(_db);
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Email.Equals(fromUserDetail.Email)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();
            var toUserDetail = ConnectedUsers.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();

            var doctor = _db.Doctors.Where(u => u.Email.Equals(fromUser.Email)).FirstOrDefault();
            var patient = new Patient();
            if (doctor == null)
            {
                doctor = _db.Doctors.Where(u => u.Email.Equals(toUser.Email)).FirstOrDefault();
                patient = _db.Patients.Where(u => u.Email.Equals(fromUser.Email)).FirstOrDefault();
            }
            else
            {
                patient = _db.Patients.Where(u => u.Email.Equals(toUser.Email)).FirstOrDefault();
            }
            if (doctor != null && patient != null)
            {
                //Check if toUserDetail is not online yet
                if (toUserDetail == null)
                {
                    toUserDetail = helper.ConvertUserToUserDetail(toUser);
                }

                helper.SyncUserDetailWhenSendMessage(fromUserDetail, toEmail, message, ConnectedUsers);
                
                Debug.WriteLine("DoctorId = " + toUser.UserId, "  PatientId = " + fromUser.UserId);
                
                MessageDetail messageDetail = helper.SaveMessageToDatabase(fromUser, patient, doctor, message);

                //Notify Receiver
                var receiver = ConnectedUsers.Where(x => x.Email == toEmail).FirstOrDefault();
                
                if (receiver != null && receiver.ConnectionId != null)
                {
                    receiver.CountMessageUnRead = business.CountMessageUnRead(toUser);
                    Clients.Client(receiver.ConnectionId).messageReceived(fromUserDetail, toUserDetail, messageDetail);
                }

                //Notify Caller
                Clients.Caller.messageReceived(fromUserDetail, toUserDetail, messageDetail);
            }
        }

        public void GetLastestChatMessage(string toEmail)
        {
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Email.Equals(fromUserDetail.Email)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();
            var toUserDetail = ConnectedUsers.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();

            var doctor = _db.Doctors.Where(u => u.Email.Equals(fromUser.Email)).FirstOrDefault();
            var patient = new Patient();
            if (doctor == null)
            {
                doctor = _db.Doctors.Where(u => u.Email.Equals(toUser.Email)).FirstOrDefault();
                patient = _db.Patients.Where(u => u.Email.Equals(fromUser.Email)).FirstOrDefault();
            }
            else
            {
                patient = _db.Patients.Where(u => u.Email.Equals(toUser.Email)).FirstOrDefault();
            }

            if (doctor != null && patient != null)
            {
                var conversation = _db.Conversations.Where(x => x.DoctorId == doctor.UserId && x.PatientId == patient.UserId).FirstOrDefault();
                var lastestConversationDetail = _db.ConversationDetails.Where(x => x.ConversationId == conversation.ConversationId).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

                MessageDetail messageDetail = new MessageDetail
                {
                    Content = lastestConversationDetail.Content,
                    Attachment = lastestConversationDetail.Attachment,
                    CreatedDate = String.Format("{0:dd/MM/yyyy HH:mm:ss}", lastestConversationDetail.CreatedDate),
                    Email = lastestConversationDetail.User.Email,
                    IsRead = lastestConversationDetail.IsRead
                };

                //Check if toUserDetail is not online yet
                if (toUserDetail == null)
                {
                    toUserDetail = helper.ConvertUserToUserDetail(toUser);
                }

                //Notify Receiver
                var receiver = ConnectedUsers.Where(x => x.Email == toEmail).FirstOrDefault();

                if (receiver != null && receiver.ConnectionId != null)
                {
                    receiver.CountMessageUnRead = business.CountMessageUnRead(toUser);
                    Clients.Client(receiver.ConnectionId).messageReceived(fromUserDetail, toUserDetail, messageDetail);
                }

                //Notify Caller
                Clients.Caller.messageReceived(fromUserDetail, toUserDetail, messageDetail);
            }
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            var item = ConnectedUsers.FirstOrDefault(x => 
                (x != null ) &&
                (x.ConnectionId == Context.ConnectionId));
            if (item != null)
            {
                ConnectedUsers.Remove(item);
                var id = Context.ConnectionId;
                var doctor = Doctors.Where(x => x.Email == item.Email).FirstOrDefault();
                var connectedUser = ConnectedUsers.Where(x => x.Email == item.Email).FirstOrDefault();
                if ((connectedUser == null) && (doctor != null))
                {
                    doctor.OnlineStatus = OnlineStatus.Offline;
                    Clients.AllExcept(id).onGetDoctorList(Doctors);
                }
            }

            return base.OnDisconnected();
        }

        #endregion

        #region WebRTC related things

        //Doctor send request for patient to view webcam
        public void RequestWebcam(string toEmail)
        {
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Email.Equals(fromUserDetail.Email)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();
            var toUserDetail = ConnectedUsers.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();
            if (toUserDetail == null)
            {
                Clients.Caller.patientOffline(toUser.FullName);
            }
            else
            {
                Clients.Client(toUserDetail.ConnectionId).RequestWebcamReceived(fromUserDetail);
            }
        }

        public void AnswerCall(bool acceptCall, string targetConnectionId)
        {
            var callingUser = ConnectedUsers.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
            var targetUser = ConnectedUsers.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

            if (callingUser != null && targetUser != null)
            {

                // Send a decline message if the callee said no
                if (acceptCall == false)
                {
                    Clients.Client(targetConnectionId).callDeclined(callingUser, string.Format("{0} did not accept your call.", callingUser.Email));
                    return;
                }

                // Tell the original caller that the call was accepted
                Clients.Caller.callAccepted(targetUser);
            }
        }

        // WebRTC Signal Handler
        public void SendSignal(string signal, string targetConnectionId)
        {
            //Doctor
            var callingUser = ConnectedUsers.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);

            //Patient
            var targetUser = ConnectedUsers.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

            // Make sure both users are valid
            if (callingUser == null || targetUser == null)
            {
                return;
            }

            // These folks are in a call together, let's let em talk WebRTC
            Clients.Client(targetConnectionId).receiveSignal(callingUser, signal);
        }

        #endregion
    }

}