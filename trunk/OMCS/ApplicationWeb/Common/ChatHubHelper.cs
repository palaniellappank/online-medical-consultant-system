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
        public void UpdateDoctorsStatus(string email, List<DoctorDetail> Doctors, List<UserDetail> ConnectedUsers)
        {
            var doctor = _db.Doctors.Where(x => x.Email.Equals(email)).FirstOrDefault();
            var doctorDetail = Doctors.Where(x => x.Email.Equals(email)).FirstOrDefault();

            //Update Doctor list status
            if (doctorDetail != null)
            {
                doctorDetail.CountMessageUnRead = business.CountMessageUnRead(doctor);

                foreach (UserDetail userDetail in ConnectedUsers)
                {
                    //Doctor always have DoctorList = null
                    if (userDetail.DoctorList != null)
                    {
                        var doctorDetailForUser = userDetail.DoctorList.Where(
                        x => x.Email == email).FirstOrDefault();
                        doctorDetailForUser.OnlineStatus = doctorDetail.OnlineStatus;
                    }
                }
            }
        }

        public int GetNumberOfWaitingPatient(string fromPatientEmail, string toDoctorEmail)
        {
            var doctor = _db.Doctors.Where(x => x.Email.Equals(toDoctorEmail)).FirstOrDefault();
            var patient = _db.Patients.Where(x => x.Email.Equals(fromPatientEmail)).FirstOrDefault();
            var conversation = _db.Conversations.Where(x => x.DoctorId == doctor.UserId && x.PatientId == patient.UserId).FirstOrDefault();
            var numOfWating = 0;
            if (conversation != null)
            {
                var lastestMessage = _db.ConversationDetails.Where(x => x.ConversationId == conversation.ConversationId).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                if (lastestMessage != null)
                {
                    numOfWating = _db.Conversations.Where(x => x.DoctorId == doctor.UserId && 
                        x.IsDoctorRead == false && x.LatestTimeFromPatient < lastestMessage.CreatedDate).Count();
                }
                else
                {
                    numOfWating = _db.Conversations.Where(x => x.DoctorId == doctor.UserId && 
                        x.IsDoctorRead == false).Count();
                }
            }
            else
            {
                numOfWating = _db.Conversations.Where(x => x.DoctorId == doctor.UserId && x.IsDoctorRead == false).Count();
            }
            return numOfWating;
        }

        /*
         * fromEmail: Logged user
         * toEmail: Choosed user to see message
         */
        public List<MessageDetail> GetMessageDetail(string fromEmail, string toEmail)
        {
            var doctor = _db.Doctors.Where(u => u.Email.Equals(fromEmail)).FirstOrDefault();
            var patient = new Patient();
            if (doctor == null)
            {
                doctor = _db.Doctors.Where(u => u.Email.Equals(toEmail)).FirstOrDefault();
                patient = _db.Patients.Where(u => u.Email.Equals(fromEmail)).FirstOrDefault();
            }
            else
            {
                patient = _db.Patients.Where(u => u.Email.Equals(toEmail)).FirstOrDefault();
            }
            var messageDetails = new List<MessageDetail>();
            if (doctor != null && patient != null)
            {
                var newestConversation = _db.Conversations.Where(
                    con => (con.PatientId == patient.UserId) && (con.DoctorId == doctor.UserId)).FirstOrDefault();

                if (newestConversation != null)
                {
                    var conversationDetails = _db.ConversationDetails.Where(cd => cd.Conversation.ConversationId == newestConversation.ConversationId).
                    OrderBy(cd => cd.CreatedDate).ToList();

                    //Convert conversationDetails to MessageDetails
                    
                    foreach (var conversationDetail in conversationDetails)
                    {
                        String date = (DateTime.Now.Subtract(conversationDetail.CreatedDate).Days) > 1 ?
                            String.Format("{0:HH:mm:ss}", conversationDetail.CreatedDate) :
                            String.Format("{0:dd/MM/yyyy HH:mm:ss}", conversationDetail.CreatedDate);
                        MessageDetail messageDetail = new MessageDetail
                        {
                            Content = conversationDetail.Content,
                            Attachment = conversationDetail.Attachment,
                            CreatedDate = date,
                            Email = conversationDetail.User.Email,
                            IsRead = conversationDetail.IsRead
                        };
                        messageDetails.Add(messageDetail);
                    }
                    if (fromEmail.Equals(doctor.Email))
                    {
                        business.MarkConversationAsRead(newestConversation, true);
                    }
                    if (fromEmail.Equals(patient.Email))
                    {
                        business.MarkConversationAsRead(newestConversation, false);
                    }
                }
            }
            return messageDetails;
        }

        /*
         * email: Email of doctor 
         * ConnectedUsers: used to detect user online or not
         */
        public List<UserDetail> GetLastestConversationList(string email, List<UserDetail> ConnectedUsers)
        {
            var doctor = _db.Doctors.Where(x => x.Email.Equals(email)).FirstOrDefault();
            var userDetailList = new List<UserDetail>();
            var conversations = _db.Conversations.Where(
                x => x.DoctorId == doctor.UserId).
                OrderByDescending(x => x.LatestTimeFromPatient
                ).ToList();

            foreach (var conversation in conversations)
            {
                var existUser = userDetailList.Where
                    (x => x.Email == conversation.Patient.Email).FirstOrDefault();
                if (existUser == null)
                {
                    //Check user online or not
                    var connectedUser = ConnectedUsers.Where
                        (x => x.Email == conversation.Patient.Email).FirstOrDefault();
                    var onlineStatus = (connectedUser != null) ? OnlineStatus.Online : OnlineStatus.Offline;
                    UserDetail userDetailCon = new UserDetail
                    {
                        FullName = conversation.Patient.FullName,
                        LastestContent = conversation.LatestContentFromPatient,
                        LastestTime = conversation.LatestTimeFromPatient,
                        ProfilePicture = conversation.Patient.ProfilePicture,
                        Email = conversation.Patient.Email,
                        IsRead = conversation.IsDoctorRead,
                        OnlineStatus = onlineStatus
                    };
                    userDetailList.Add(userDetailCon);
                }
            }
            return userDetailList;
        }

        public List<DoctorDetail> GetListDoctorConversation(string email, List<UserDetail> ConnectedUsers)
        {
            var patient = _db.Patients.Where(x => x.Email.Equals(email)).FirstOrDefault();
            var doctorListDB = _db.Doctors.ToList();
            var doctorListResult = new List<DoctorDetail>();
            foreach (var doctor in doctorListDB)
            {
                var lastestConversation = _db.Conversations.Where(
                    x => (x.PatientId == patient.UserId)
                        && (x.DoctorId == doctor.UserId)).
                    OrderByDescending(x => x.LatestTimeFromPatient
                    ).FirstOrDefault();
                // If not conversation then create new 
                if (lastestConversation == null)
                {
                    lastestConversation = new Conversation();
                    lastestConversation.IsPatientRead = true;
                }
                //Check user online or not
                var connectedUser = ConnectedUsers.Where
                    (x => x.Email == doctor.Email).FirstOrDefault();
                var onlineStatus = (connectedUser != null) ? OnlineStatus.Online : OnlineStatus.Offline;
                DoctorDetail userDetailCon = new DoctorDetail
                {
                    FullName = doctor.FullName,
                    LastestContent = lastestConversation.LatestContentFromPatient,
                    LastestTime = lastestConversation.LatestTimeFromPatient,
                    ProfilePicture = doctor.ProfilePicture,
                    Email = doctor.Email,
                    IsRead = lastestConversation.IsPatientRead,
                    OnlineStatus = onlineStatus,
                    SpecialtyField = doctor.SpecialtyField.Name
                };
                doctorListResult.Add(userDetailCon);
            }
            return doctorListResult;
        }

        /*
         * Get all doctor from database when init
         */
        public List<DoctorDetail> GetListDoctors()
        {
            var doctorListDB = _db.Doctors.ToList();
            var doctorListResult = new List<DoctorDetail>();
            foreach (var doctor in doctorListDB)
            {
                DoctorDetail doctorDetail = new DoctorDetail
                {
                    FullName = doctor.FullName,
                    OnlineStatus = OnlineStatus.Offline,
                    SpecialtyField = doctor.SpecialtyField.Name,
                    Email = doctor.Email,
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
                Email = user.Email,
                OnlineStatus = Common.OnlineStatus.Offline,
                ProfilePicture = user.ProfilePicture
            };
            return userDetail;
        }

        /* 
         * user: send message user
         * toEmail: User who receive message
         * Update DoctorList for Patient
         * And ConversationList for Doctor
         * To see the lastest chat content
         */
        public void SyncUserDetailWhenSendMessage(UserDetail user, string toEmail, string message, List<UserDetail> ConnectedUsers)
        {
            //Mark login user DoctorList and ConversationList as read
            if (user.DoctorList != null)
            {
                UserDetail doctor = user.DoctorList.Where(
                        x=>x.Email == toEmail
                    ).FirstOrDefault();
                doctor.LastestContent = message;
                doctor.IsRead = true;
                doctor.LastestTime = DateTime.Now;
            }
            if (user.ConversationList != null)
            {
                UserDetail patient = user.ConversationList.Where(
                        x => x.Email == toEmail
                    ).FirstOrDefault();
                patient.LastestContent = message;
                patient.IsRead = true;
                patient.LastestTime = DateTime.Now;
            }

            //Mark receive user DoctorList and ConversationList as un-read
            var receiveUser = ConnectedUsers.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();
            if (receiveUser != null)
            {
                if (receiveUser.DoctorList != null)
                {
                    UserDetail doctor = receiveUser.DoctorList.Where(
                            x => x.Email == user.Email
                        ).FirstOrDefault();
                    doctor.LastestContent = message;
                    doctor.IsRead = false;
                    doctor.LastestTime = DateTime.Now;
                }             
                if (receiveUser.ConversationList != null)
                {
                    UserDetail patient = receiveUser.ConversationList.Where(
                            x => x.Email == user.Email
                        ).FirstOrDefault();

                    //This is the first time patient send message to doctor
                    if (patient == null)
                    {
                        patient = new UserDetail
                        {
                            FullName = user.FullName,
                            ProfilePicture = user.ProfilePicture,
                            Email = user.Email,
                            OnlineStatus = Common.OnlineStatus.Online
                        };
                        receiveUser.ConversationList.Add(patient);
                    }
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
                x => (x.PatientId == patient.UserId && x.DoctorId == doctor.UserId)).FirstOrDefault();

            if (conversation == null)
            {
                conversation = new Conversation
                {
                    DoctorId = doctor.UserId,
                    PatientId = patient.UserId,
                    LatestTimeFromDoctor = DateTime.Now,
                    LatestTimeFromPatient = DateTime.Now
                };
                _db.Conversations.Add(conversation);
            }

            if (fromUser.Email == patient.Email)
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
                Email = fromUser.Email,
                //CreatedDate = String.Format("{0:H:mm:ss}", DateTime.Now),
                CreatedDate = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now),
                IsRead = false
            };

            _db.ConversationDetails.Add(conversationDetail);
            _db.SaveChanges();
            return messageDetail;
        }
    }

}