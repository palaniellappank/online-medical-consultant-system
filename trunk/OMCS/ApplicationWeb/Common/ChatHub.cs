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

        public void ConnectDoctor(string username)
        {
            var id = Context.ConnectionId;

            var doctor = _db.Doctors.Where(x=>x.Username.Equals(username)).FirstOrDefault();
            var doctorDetail = Doctors.Where(x => x.Username.Equals(username)).FirstOrDefault();

            helper.UpdateDoctorsStatus(id, username, Doctors, ConnectedUsers);

            //Add User
            UserDetail userDetail = new UserDetail
            {
                ConnectionId = id,
                CountMessageUnRead = business.CountMessageUnRead(doctor),
                ProfilePicture = doctor.ProfilePicture,
                FullName = doctor.FullName,
                Username = doctor.Username,
                IsOnline = doctor.IsOnline
            };

            //Show List of Lastest contact
            var userDetailList = helper.GetLastestConversationList(username, ConnectedUsers);
            userDetail.ConversationList = userDetailList;
            ConnectedUsers.Add(userDetail);

            Debug.WriteLine("Size of userDetailList: " + userDetailList.Count);

            Clients.Caller.onGetConversationList(userDetailList);
            Clients.AllExcept(id).onRefreshDoctorList();
        }

        public void ConnectPatient(string username)
        {
            var id = Context.ConnectionId;
            var userDetail = ConnectedUsers.Where(x => x.Username.Equals(username)).FirstOrDefault();
            if (userDetail == null)
            {
                var user = _db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
                userDetail = new UserDetail { 
                    ConnectionId = id,
                    CountMessageUnRead = business.CountMessageUnRead(user),
                    Username = username,
                    FullName = user.FullName, ProfilePicture = user.ProfilePicture,
                    IsOnline = true
                };
                ConnectedUsers.Add(userDetail);
                userDetail.DoctorList = helper.GetListDoctorConversation(username, ConnectedUsers);
            }
            Clients.Caller.onGetDoctorList(userDetail.DoctorList);
            Clients.Caller.onMessageUnRead(userDetail);
        }

        public void GetMessageList(string username)
        {
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Username.Equals(fromUserDetail.Username)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
            var toUserDetail = ConnectedUsers.Where(x => x.Username.Equals(username)).FirstOrDefault();

            //Check if toUserDetail is not online yet
            if (toUserDetail == null)
            {
                toUserDetail = helper.ConvertUserToUserDetail(toUser);
            }
            List<MessageDetail> userDetails = helper.GetMessageDetail(fromUser.Username, toUser.Username);
            Clients.Caller.onGetMessageList(fromUserDetail, toUserDetail, userDetails);
            
        }

        public void SendMessageTo(string toUsername, string message)
        {
            business = new ConversationBusiness(_db);
            Debug.WriteLine(toUsername + " " + message);
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Username.Equals(fromUserDetail.Username)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Username.Equals(toUsername)).FirstOrDefault();
            var toUserDetail = ConnectedUsers.Where(x => x.Username.Equals(toUsername)).FirstOrDefault();

            var doctor = _db.Doctors.Where(u => u.Username.Equals(fromUser.Username)).FirstOrDefault();
            var patient = new Patient();
            if (doctor == null)
            {
                doctor = _db.Doctors.Where(u => u.Username.Equals(toUser.Username)).FirstOrDefault();
                patient = _db.Patients.Where(u => u.Username.Equals(fromUser.Username)).FirstOrDefault();
            }
            else
            {
                patient = _db.Patients.Where(u => u.Username.Equals(toUser.Username)).FirstOrDefault();
            }
            if (doctor != null && patient != null)
            {
                //Check if toUserDetail is not online yet
                if (toUserDetail == null)
                {
                    toUserDetail = helper.ConvertUserToUserDetail(toUser);
                }

                helper.SyncUserDetailWhenSendMessage(fromUserDetail, toUsername, message, ConnectedUsers);
                
                Debug.WriteLine("DoctorId = " + toUser.UserId, "  PatientId = " + fromUser.UserId);
                
                MessageDetail messageDetail = helper.SaveMessageToDatabase(fromUser, patient, doctor, message);

                //Notify Receiver
                var receiver = ConnectedUsers.Where(x => x.Username == toUsername).FirstOrDefault();
                
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
            Debug.WriteLine("haha");
            if (item != null)
            {
                ConnectedUsers.Remove(item);
                var id = Context.ConnectionId;
                Debug.WriteLine(id);
                var doctor = Doctors.Where(x => x.Username == item.Username).FirstOrDefault();
                var connectedUser = ConnectedUsers.Where(x => x.Username == item.Username).FirstOrDefault();
                if ((connectedUser == null) && (doctor != null))
                {
                    Debug.WriteLine(doctor);
                    doctor.IsOnline = false;
                    Clients.AllExcept(id).onGetDoctorList(Doctors);
                }
            }

            return base.OnDisconnected();
        }

        #endregion
    }

}