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
        OMCSDBContext _db = new OMCSDBContext();
        ConversationBusiness business = new ConversationBusiness();
        #region Data Members

        //Hold all connection for Doctor or Patient
        //One use can have many connection (by open tabs,...)
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        //List of all Doctor and their Status
        static List<DoctorDetail> Doctors = new List<DoctorDetail>();

        #endregion

        #region Methods

        public void ConnectDoctor(string username)
        {
            var id = Context.ConnectionId;

            var doctor = _db.Doctors.Where(x=>x.Username.Equals(username)).FirstOrDefault();
            var doctorDetail = Doctors.Where(x => x.Username.Equals(username)).FirstOrDefault();

            //Update Doctor list status
            if (doctorDetail == null)
            {
                doctorDetail = new DoctorDetail
                {
                    ConnectionId = id,
                    CountMessageUnRead = business.CountMessageUnRead(doctor),
                    ProfilePicture = doctor.ProfilePicture,
                    IsOnline = doctor.IsOnline,
                    FullName = doctor.FullName,
                    Username = doctor.Username,
                    SpeciatyField = doctor.SpecialtyField.Name
                };
                Doctors.Add(doctorDetail);
            }
            else
            {
                doctorDetail.IsOnline = doctor.IsOnline;
            }

            //Add User
            UserDetail userDetail = new UserDetail
            {
                ConnectionId = id,
                CountMessageUnRead = business.CountMessageUnRead(doctor),
                ProfilePicture = doctor.ProfilePicture,
                FullName = doctor.FullName,
                Username = doctor.Username,
            };

            ConnectedUsers.Add(userDetail);

            // send to caller
            Clients.Caller.onConnected(id, doctorDetail);

            // send to all except caller client
            Clients.AllExcept(id).onGetDoctorList(Doctors);
        }

        public void ConnectPatient(string username)
        {
            var id = Context.ConnectionId;
            var userDetail = ConnectedUsers.Where(x => x.Username.Equals(username)).FirstOrDefault();
            if (userDetail == null)
            {
                var user = _db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, 
                    Username = username, CountMessageUnRead = 0,
                    FullName = user.FullName, ProfilePicture = user.ProfilePicture
                });

                var DoctorListDB = _db.Doctors.ToList();
                foreach (var doctor in DoctorListDB)
                {
                    if (Doctors.Where(d => d.Username.Equals(doctor.Username)).FirstOrDefault() == null)
                    {
                        DoctorDetail doctorDetail = new DoctorDetail
                        {
                            FullName = doctor.FullName,
                            IsOnline = false,
                            SpeciatyField = doctor.SpecialtyField.Name,
                            Username = doctor.Username
                        };
                        Doctors.Add(doctorDetail);
                    }
                }

                // send to caller
                Clients.Caller.onGetDoctorList(Doctors);
            }
        }

        public void GetMessageList(string username)
        {
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Username.Equals(fromUserDetail.Username)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();

            var doctor = _db.Doctors.Where(u => u.Username.Equals(username)).FirstOrDefault();
            Debug.WriteLine(doctor.Username);
            if (doctor != null)
            {
                var patientDetail = ConnectedUsers.Where(cu => cu.ConnectionId == id).FirstOrDefault();
                Debug.WriteLine(patientDetail.Username);
                var patient = _db.Patients.Where(u => u.Username.Equals(patientDetail.Username)).FirstOrDefault();
                Debug.WriteLine("Patient: " + patient.Username + "  " + "Doctor: " + doctor.Username);
                DoctorDetail doctorDetail = Doctors.Where(u => u.Username.Equals(username)).FirstOrDefault();
                var newestConversation = _db.Conversations.Where(
                    con => (con.PatientId == patient.UserId) && (con.DoctorId == doctor.UserId))
                    .OrderByDescending(con => con.DateConsulted).FirstOrDefault();

                if (newestConversation != null)
                {
                    var conversationDetails = _db.ConversationDetails.Where(cd => cd.Conversation.ConversationId == newestConversation.ConversationId).
                    OrderBy(cd => cd.CreatedDate).ToList();

                    //Convert conversationDetails to MessageDetails
                    var messageDetails = new List<MessageDetail>();
                    foreach (var conversationDetail in conversationDetails)
                    {
                        String date = (DateTime.UtcNow.Subtract(conversationDetail.CreatedDate).Days) > 1 ?
                            String.Format("{0:HH:mm:ss}", conversationDetail.CreatedDate) :
                            String.Format("{0:dd/mm/yyyy HH:mm:ss}", conversationDetail.CreatedDate);
                        MessageDetail messageDetail = new MessageDetail
                        {
                            Content = conversationDetail.Content,
                            CreatedDate = date,
                            Username = conversationDetail.User.Username
                        };
                        messageDetails.Add(messageDetail);
                    }
                    Debug.WriteLine(messageDetails.Count);
                    Clients.Caller.onGetMessageList(patientDetail, doctorDetail, messageDetails);
                }
                else
                {
                    Clients.Caller.onGetMessageList(patientDetail, doctorDetail, "");
                }
            }
        }

        public void SendMessageToDoctor(string toUsername, string message)
        {
            Debug.WriteLine(toUsername + " " + message);
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Username.Equals(fromUserDetail.Username)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Username.Equals(toUsername)).FirstOrDefault();
            

            //Store in database
            Conversation conversation = _db.Conversations.Where(
                x => (x.PatientId == fromUser.UserId && x.DoctorId == toUser.UserId))
            .OrderByDescending(x => x.DateConsulted).FirstOrDefault();

            Debug.WriteLine("DoctorId = " + toUser.UserId, "  PatientId = " + fromUser.UserId);
            if (conversation == null)
            {
                conversation = new Conversation
                {
                    DoctorId = toUser.UserId,
                    PatientId = fromUser.UserId,
                    DateConsulted = DateTime.UtcNow
                };
                _db.Conversations.Add(conversation);
            }

            ConversationDetail conversationDetail = new ConversationDetail
            {
                UserId = fromUser.UserId,
                Content = message,
                Conversation = conversation,
                CreatedDate = DateTime.UtcNow
            };

            MessageDetail messageDetail = new MessageDetail
            {
                 Content = message,
                 Username = fromUser.Username,
                 CreatedDate = String.Format("{0:H:mm:ss}", DateTime.Now)
            };

            _db.ConversationDetails.Add(conversationDetail);
            _db.SaveChanges();

            //Notify Receiver
            var toUserDetails = ConnectedUsers.Where(x => x.Username == toUsername).ToList();
            if (toUserDetails != null) 
            {
                foreach(var toUserDetail in toUserDetails)
                {
                    toUserDetail.CountMessageUnRead = business.CountMessageUnRead(toUser);
                    if (toUserDetail != null && toUserDetail.ConnectionId != null)
                        Clients.Client(toUserDetail.ConnectionId).messageReceived(fromUserDetail, toUserDetail, messageDetail);
                }
            }

            //Notify Caller
            Clients.Caller.messageReceived(fromUserDetail, messageDetail);
        }

        public void SendPrivateMessage(string toUserId, string message, int conversationid, string username)
        {
            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            toUser.CountMessageUnRead += 1;
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.Username, message);

                // send to caller doctor
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.Username, message);

                Clients.Client(toUserId).sendPrivateMessageToDoctor(toUser.CountMessageUnRead);
                //Debug.WriteLine(toUser.CountMessageUnRead);
                //Debug.WriteLine("Da vao day roi ne");
                //Debug.WriteLine(toUserId + fromUserId);
            }

            var conversation = _db.Conversations.Find(conversationid);
            var user = _db.Users.Where(u => u.Username == username).FirstOrDefault();
            var conversationDetail = new ConversationDetail
            {
                Conversation = conversation,
                Content = message,
                CreatedDate = DateTime.UtcNow,
                User = user
            };
            //_db.Conversations.Add(conversation);
            Debug.WriteLine(conversationid);
            Debug.WriteLine(username);
            _db.ConversationDetails.Add(conversationDetail);
            _db.SaveChanges();

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