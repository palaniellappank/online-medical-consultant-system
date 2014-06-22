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

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            //Debug.WriteLine(userName + id);
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName, CountMessageUnRead = 0 });

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        public void ConnectPatient(string userName)
        {
            var id = Context.ConnectionId;
            var DoctorListDB = _db.Doctors.ToList();
            foreach (var doctor in DoctorListDB)
            {
                DoctorDetail doctorDetail = new DoctorDetail
                {
                    FullName = doctor.FullName,
                    IsOnline = false,
                    SpeciatyField = doctor.SpecialtyField.Name,
                    UserName = doctor.Username
                };
                Doctors.Add(doctorDetail);
            }
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName, CountMessageUnRead = 0 });

                // send to caller
                Clients.Caller.onConnected(id, userName, Doctors);
            }
        }

        public void GetMessageFrom(string username)
        {
            var doctor = _db.Doctors.Where(u => u.Username.Equals(username)).FirstOrDefault();
            Debug.WriteLine(doctor.Username);
            if (doctor != null)
            {
                var id = Context.ConnectionId;
                var patientDetail = ConnectedUsers.Where(cu => cu.ConnectionId.Equals(id)).FirstOrDefault();
                Debug.WriteLine(patientDetail.UserName);
                var patient = _db.Patients.Where(u => u.Username.Equals(username)).FirstOrDefault();

                var newestConversation = _db.Conversations.Where(
                    con => (con.Patient == patient) && (con.Doctor == doctor))
                    .OrderByDescending(con => con.DateConsulted);

                var conversationDetails = _db.ConversationDetails.Where(cd => cd.Conversation == newestConversation).
                    OrderBy(cd => cd.CreatedDate).ToList();

                //Convert conversationDetails to MessageDetails
                var messageDetails = new List<MessageDetail>();
                foreach (var conversationDetail in conversationDetails)
                {
                    MessageDetail messageDetail = new MessageDetail
                    {
                        Content = conversationDetail.Content,
                        CreatedDate = conversationDetail.CreatedDate,
                        Username = conversationDetail.User.Username
                    };
                    messageDetails.Add(messageDetail);
                }

                DoctorDetail doctorDetail = Doctors.Where(u => u.UserName.Equals(username)).FirstOrDefault();
                Clients.Caller.onGetMessage(doctorDetail, messageDetails);
            }
        }

        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, message);

            // Broad cast message
            Clients.All.messageReceived(userName, message);
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

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {
            CurrentMessage.Add(new MessageDetail { Username = userName, Content = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        #endregion
    }

}