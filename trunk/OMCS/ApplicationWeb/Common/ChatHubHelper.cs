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
    public class ChatHubHelper
    {
        OMCSDBContext _db;
        ConversationBusiness business;

        public ChatHubHelper(OMCSDBContext _db) 
        {
            this._db = _db;
            business = new ConversationBusiness(_db);
        }

        /* Update Doctor Status for all user
         */
        public void UpdateDoctorsStatus(string id, string username, List<DoctorDetail> Doctors, List<UserDetail> ConnectedUsers)
        {
            var doctor = _db.Doctors.Where(x=>x.Username.Equals(username)).FirstOrDefault();
            var doctorDetail = Doctors.Where(x => x.Username.Equals(username)).FirstOrDefault();

            //Update Doctor list status
            if (doctorDetail != null)
            {
                doctorDetail.CountMessageUnRead = business.CountMessageUnRead(doctor);
                doctorDetail.IsOnline = doctor.IsOnline;
            }

            foreach (UserDetail userDetail in ConnectedUsers)
            {
                var doctorDetailForUser = userDetail.DoctorList.Where(
                    x => x.Username == username).FirstOrDefault();
                doctorDetailForUser.IsOnline = doctorDetail.IsOnline;
            }
        }

        /*
         * fromUsername: Logged user
         * toUsername: Choosed user to see message
         */
        public List<MessageDetail> GetMessageDetail(string fromUsername, string toUsername)
        {

            var doctor = _db.Doctors.Where(u => u.Username.Equals(fromUsername)).FirstOrDefault();
            var patient = new Patient();
            if (doctor == null)
            {
                doctor = _db.Doctors.Where(u => u.Username.Equals(toUsername)).FirstOrDefault();
                patient = _db.Patients.Where(u => u.Username.Equals(fromUsername)).FirstOrDefault();
            }
            else
            {
                patient = _db.Patients.Where(u => u.Username.Equals(toUsername)).FirstOrDefault();
            }
            var messageDetails = new List<MessageDetail>();
            if (doctor != null && patient != null)
            {
                Debug.WriteLine("Patient: " + patient.Username + "  " + "Doctor: " + doctor.Username);
                var newestConversation = _db.Conversations.Where(
                    con => (con.PatientId == patient.UserId) && (con.DoctorId == doctor.UserId))
                    .OrderByDescending(con => con.DateConsulted).FirstOrDefault();

                if (newestConversation != null)
                {
                    var conversationDetails = _db.ConversationDetails.Where(cd => cd.Conversation.ConversationId == newestConversation.ConversationId).
                    OrderBy(cd => cd.CreatedDate).ToList();

                    //Convert conversationDetails to MessageDetails
                    
                    foreach (var conversationDetail in conversationDetails)
                    {
                        String date = (DateTime.Now.Subtract(conversationDetail.CreatedDate).Days) > 1 ?
                            String.Format("{0:HH:mm:ss}", conversationDetail.CreatedDate) :
                            String.Format("{0:dd/mm/yyyy HH:mm:ss}", conversationDetail.CreatedDate);
                        MessageDetail messageDetail = new MessageDetail
                        {
                            Content = conversationDetail.Content,
                            CreatedDate = date,
                            Username = conversationDetail.User.Username,
                            IsRead = conversationDetail.IsRead
                        };
                        messageDetails.Add(messageDetail);
                    }
                    Debug.WriteLine(messageDetails.Count);
                    if (fromUsername.Equals(doctor.Username))
                    {
                        business.MarkConversationAsRead(newestConversation, true);
                    }
                    if (fromUsername.Equals(patient.Username))
                    {
                        business.MarkConversationAsRead(newestConversation, false);
                    }
                }
            }
            return messageDetails;
        }

        /*
         * username: Username of doctor 
         * ConnectedUsers: used to detect user online or not
         */
        public List<UserDetail> GetLastestConversationList(string username, List<UserDetail> ConnectedUsers)
        {
            var doctor = _db.Doctors.Where(x => x.Username.Equals(username)).FirstOrDefault();
            var userDetailList = new List<UserDetail>();
            var conversations = _db.Conversations.Where(
                x => x.DoctorId == doctor.UserId).
                OrderByDescending(x => x.LatestTimeFromPatient
                ).ToList();

            foreach (var conversation in conversations)
            {
                var existUser = userDetailList.Where
                    (x => x.Username == conversation.Patient.Username).FirstOrDefault();
                if (existUser == null)
                {
                    //Check user online or not
                    var connectedUser = ConnectedUsers.Where
                        (x => x.Username == conversation.Patient.Username).FirstOrDefault();
                    var IsOnline = (connectedUser != null && connectedUser.IsOnline) ? true : false;
                    UserDetail userDetailCon = new UserDetail
                    {
                        FullName = conversation.Patient.FullName,
                        LastestContent = conversation.LatestContentFromPatient,
                        LastestTime = conversation.LatestTimeFromPatient,
                        ProfilePicture = conversation.Patient.ProfilePicture,
                        Username = conversation.Patient.Username,
                        IsRead = conversation.IsDoctorRead,
                        IsOnline = IsOnline
                    };
                    userDetailList.Add(userDetailCon);
                }
            }
            return userDetailList;
        }

        public List<DoctorDetail> GetListDoctorConversation(string username, List<UserDetail> ConnectedUsers)
        {
            var patient = _db.Patients.Where(x => x.Username.Equals(username)).FirstOrDefault();
            var doctorListDB = _db.Doctors.ToList();
            var doctorListResult = new List<DoctorDetail>();
            foreach (var doctor in doctorListDB)
            {
                var lastestConversation = _db.Conversations.Where(
                    x => (x.PatientId == patient.UserId)
                        && (x.DoctorId == doctor.UserId)).
                    OrderByDescending(x => x.LatestTimeFromPatient
                    ).FirstOrDefault();
                //Check user online or not
                var connectedUser = ConnectedUsers.Where
                    (x => x.Username == doctor.Username).FirstOrDefault();
                var IsOnline = (connectedUser != null && connectedUser.IsOnline) ? true : false;
                DoctorDetail userDetailCon = new DoctorDetail
                {
                    FullName = doctor.FullName,
                    LastestContent = lastestConversation.LatestContentFromPatient,
                    LastestTime = lastestConversation.LatestTimeFromPatient,
                    ProfilePicture = doctor.ProfilePicture,
                    Username = doctor.Username,
                    IsRead = lastestConversation.IsPatientRead,
                    IsOnline = IsOnline,
                    SpeciatyField = doctor.SpecialtyField.Name
                };
                doctorListResult.Add(userDetailCon);
            }
            return doctorListResult;
        }

        public List<DoctorDetail> GetListDoctors()
        {
            var doctorListDB = _db.Doctors.ToList();
            var doctorListResult = new List<DoctorDetail>();
            foreach (var doctor in doctorListDB)
            {
                DoctorDetail doctorDetail = new DoctorDetail
                {
                    FullName = doctor.FullName,
                    IsOnline = false,
                    SpeciatyField = doctor.SpecialtyField.Name,
                    Username = doctor.Username,
                    ProfilePicture = doctor.ProfilePicture
                };
                doctorListResult.Add(doctorDetail);
            }
            return doctorListResult;
        }

        public UserDetail ConvertUserToUserDetail(User user)
        {
            UserDetail userDetail = new UserDetail
            {
                FullName = user.FullName,
                Username = user.Username,
                IsOnline = false,
                ProfilePicture = user.ProfilePicture
            };
            return userDetail;
        }

        /* 
         * toUsername: User who receive message
         * Update DoctorList for Patient
         * And ConversationList for Doctor
         * To see the lastest chat content
         */
        public void SyncUserDetailWhenSendMessage(UserDetail user, string toUsername, string message, List<UserDetail> ConnectedUsers)
        {
            //Mark login user DoctorList and ConversationList as read
            if (user.DoctorList != null)
            {
                UserDetail doctor = user.DoctorList.Where(
                        x=>x.Username == toUsername
                    ).FirstOrDefault();
                doctor.LastestContent = message;
                doctor.IsRead = true;
                doctor.LastestTime = DateTime.Now;
            }
            if (user.ConversationList != null)
            {
                UserDetail patient = user.ConversationList.Where(
                        x => x.Username == toUsername
                    ).FirstOrDefault();
                patient.LastestContent = message;
                patient.IsRead = true;
                patient.LastestTime = DateTime.Now;
            }

            //Mark receive user DoctorList and ConversationList as un-read
            var receiveUser = ConnectedUsers.Where(x => x.Username.Equals(toUsername)).FirstOrDefault();
            if (receiveUser != null)
            {
                if (receiveUser.DoctorList != null)
                {
                    UserDetail doctor = receiveUser.DoctorList.Where(
                            x => x.Username == user.Username
                        ).FirstOrDefault();
                    doctor.LastestContent = message;
                    doctor.IsRead = false;
                    doctor.LastestTime = DateTime.Now;
                }
                if (receiveUser.ConversationList != null)
                {
                    UserDetail patient = receiveUser.ConversationList.Where(
                            x => x.Username == user.Username
                        ).FirstOrDefault();
                    patient.LastestContent = message;
                    patient.IsRead = false;
                    patient.LastestTime = DateTime.Now;
                }
            }
            
        }

        public MessageDetail SaveMessageToDatabase(User fromUser, Patient patient, Doctor doctor, String message)
        {
            //Store in database
            Conversation conversation = _db.Conversations.Where(
                x => (x.PatientId == patient.UserId && x.DoctorId == doctor.UserId))
            .OrderByDescending(x => x.DateConsulted).FirstOrDefault();

            if (conversation == null)
            {
                conversation = new Conversation
                {
                    DoctorId = doctor.UserId,
                    PatientId = patient.UserId,
                    DateConsulted = DateTime.Now,
                    LatestTimeFromDoctor = DateTime.Now,
                    LatestTimeFromPatient = DateTime.Now
                };
                _db.Conversations.Add(conversation);
            }

            if (fromUser.Username == patient.Username)
            {
                conversation.LatestTimeFromPatient = DateTime.Now;
                conversation.LatestContentFromPatient = message;
                conversation.IsDoctorRead = false;
            }
            else
            {
                conversation.LatestTimeFromDoctor = DateTime.Now;
                conversation.LatestContentFromDoctor = message;
                conversation.IsPatientRead = false;
            }
            

            ConversationDetail conversationDetail = new ConversationDetail
            {
                UserId = fromUser.UserId,
                Content = message,
                Conversation = conversation,
                CreatedDate = DateTime.Now,
                IsRead = false
            };

            MessageDetail messageDetail = new MessageDetail
            {
                Content = message,
                Username = fromUser.Username,
                CreatedDate = String.Format("{0:H:mm:ss}", DateTime.Now),
                IsRead = false
            };

            _db.ConversationDetails.Add(conversationDetail);
            _db.SaveChanges();
            return messageDetail;
        }
    }

}