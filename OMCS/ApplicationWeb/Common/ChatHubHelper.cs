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

        public void UpdateDoctorsStatus(string id, string username, List<DoctorDetail> Doctors)
        {
            var doctor = _db.Doctors.Where(x=>x.Username.Equals(username)).FirstOrDefault();
            var doctorDetail = Doctors.Where(x => x.Username.Equals(username)).FirstOrDefault();

            //Update Doctor list status
            if (doctorDetail != null)
            {
                doctorDetail.CountMessageUnRead = business.CountMessageUnRead(doctor);
                doctorDetail.IsOnline = doctor.IsOnline;
            }
        }

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
                        business.MarkConversationAsRead(newestConversation);
                    }
                }
            }
            return messageDetails;
        }

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
                        IsRead = conversation.IsRead,
                        IsOnline = IsOnline
                    };
                    userDetailList.Add(userDetailCon);
                }
            }
            return userDetailList;
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
    }

}