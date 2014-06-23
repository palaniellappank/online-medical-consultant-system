using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat.Common;
using OMCS.DAL.Model;
using System.Diagnostics;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        OMCSDBContext _db = new OMCSDBContext();
        #region Data Members

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        static List<DoctorDetail> Doctors = new List<DoctorDetail>();

        #endregion

        #region Methods

        public void Connect(string username)
        {
            var id = Context.ConnectionId;

            var user = _db.Users.Where(x=>x.Username.Equals(username)).FirstOrDefault();

            //Debug.WriteLine(userName + id);
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, 
                    UserName = username, CountMessageUnRead = 0,
                    FullName = user.FullName, ProfilePicture = user.ProfilePicture
                });

                // send to caller
                Clients.Caller.onConnected(id, username, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, username);
            }
        }

        public void ConnectPatient(string username)
        {
            var id = Context.ConnectionId;
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                var user = _db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, 
                    UserName = username, CountMessageUnRead = 0,
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
                Clients.Caller.onConnected(id, username, Doctors);
            }
        }

        public void GetMessageList(string username)
        {
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Username.Equals(fromUserDetail.UserName)).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();

            var doctor = _db.Doctors.Where(u => u.Username.Equals(username)).FirstOrDefault();
            Debug.WriteLine(doctor.Username);
            if (doctor != null)
            {
                var patientDetail = ConnectedUsers.Where(cu => cu.ConnectionId.Equals(id)).FirstOrDefault();
                Debug.WriteLine(patientDetail.UserName);
                var patient = _db.Patients.Where(u => u.Username.Equals(patientDetail.UserName)).FirstOrDefault();
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
                            CreatedDate = String.Format("{0:HH mm ss}", DateTime.UtcNow)
                            ,
                            Username = conversationDetail.User.Username
                        };
                        messageDetails.Add(messageDetail);
                    }
                    Clients.Caller.onGetMessage(doctorDetail, messageDetails);
                }
                else
                {
                    Clients.Caller.onGetMessageList(doctorDetail, "");
                }
            }
        }

        public void SendMessageToDoctor(string toUsername, string message)
        {
            Debug.WriteLine(toUsername + " " + message);
            var id = Context.ConnectionId;
            var fromUserDetail = ConnectedUsers.Where(x => x.ConnectionId == id).FirstOrDefault();
            var fromUser = _db.Users.Where(x => x.Username.Equals(fromUserDetail.UserName)).FirstOrDefault();
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
            var toUserDetail = ConnectedUsers.Where(x => x.UserName == toUsername).FirstOrDefault();
            if (toUserDetail != null) 
            {
                Clients.Client(toUserDetail.ConnectionId).messageReceived(fromUserDetail, message);
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
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);

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
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }

            return base.OnDisconnected();
        }

        #endregion
    }

}