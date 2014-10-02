using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using OMCS.DAL.Model;
using Newtonsoft.Json.Linq;

namespace OMCS.BLL
{
    public class ConversationBusiness : BaseBusiness
    {
        private OMCSDBContext _db;
        public ConversationBusiness(OMCSDBContext context)
        {
            _db = context;
        }
        public int CountMessageUnRead(User user)
        {
            int countMessageUnRead = 0;
            List<Conversation> conversations;
            var doctor = _db.Doctors.Where(
                x => (x.Email == user.Email)).FirstOrDefault();
            if (doctor != null)
            {
                conversations = _db.Conversations.Where(
                    x => (x.DoctorId == user.UserId)).ToList();
                countMessageUnRead = conversations.Count(x => x.IsDoctorRead == false);
            }
            else
            {
                conversations = _db.Conversations.Where(
                    x => (x.PatientId == user.UserId)).ToList();
                countMessageUnRead = conversations.Count(x => x.IsPatientRead == false);
            }
            return countMessageUnRead;
        }

        public void MarkConversationAsRead(Conversation conversation, bool isDoctor)
        {
            if (isDoctor)
            {
                conversation.IsDoctorRead = true;
            }
            else
            {
                conversation.IsPatientRead = true;
            }
            _db.Entry(conversation).State = EntityState.Modified;

            List<ConversationDetail> conversationDetails = _db.ConversationDetails.Where(
                x => x.ConversationId == conversation.ConversationId).ToList();
            foreach (var conversationDetail in conversationDetails)
            {
                conversationDetail.IsRead = true;
                _db.Entry(conversationDetail).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }

        public JArray GetMessageByTreatment(int treatmentId)
        {
            var treatment = _db.TreatmentHistories.Find(treatmentId);
            var doctor = treatment.Doctor;
            var patient = treatment.Patient;
            var conversationJson = new JArray();

            if (doctor != null && patient != null)
            {
                var conversation = _db.Conversations.Where(
                    con => (con.PatientId == patient.UserId) && (con.DoctorId == doctor.UserId)).FirstOrDefault();

                if (conversation != null)
                {
                    var conversationDetails = _db.ConversationDetails.Where(cd => cd.Conversation.ConversationId == conversation.ConversationId
                        && treatment.ConversationFromId <= cd.ConversationDetailId && treatment.ConversationToId >= cd.ConversationDetailId).
                    OrderBy(cd => cd.CreatedDate).ToList();

                    //Convert conversationDetails to MessageDetails
                    foreach (var conversationDetail in conversationDetails)
                    {
                        String date = (DateTime.Now.Subtract(conversationDetail.CreatedDate).Days) > 1 ?
                            String.Format("{0:HH:mm:ss}", conversationDetail.CreatedDate) :
                            String.Format("{0:dd/MM/yyyy HH:mm:ss}", conversationDetail.CreatedDate);
                        dynamic messageDetail = new JObject();
                        messageDetail.id = conversationDetail.ConversationDetailId;
                        messageDetail.Content = conversationDetail.Content;
                        messageDetail.Email = conversationDetail.User.Email;
                        messageDetail.Attachment = conversationDetail.Attachment;
                        messageDetail.CreatedDate = date;
                        conversationJson.Add(messageDetail);
                    }
                }
            }
            return conversationJson;
        }

        public JArray GetMessageByConversation(string fromEmail, string toEmail)
        {
            var doctor = GetDoctor(fromEmail, toEmail);
            var patient = GetPatient(fromEmail, toEmail);
            var conversationJson = new JArray();

            if (doctor != null && patient != null)
            {
                var conversation = _db.Conversations.Where(
                    con => (con.PatientId == patient.UserId) && (con.DoctorId == doctor.UserId)).FirstOrDefault();

                if (conversation != null)
                {
                    var conversationDetails = _db.ConversationDetails.Where(cd => cd.Conversation.ConversationId == conversation.ConversationId).
                    OrderBy(cd => cd.CreatedDate).ToList();

                    //Convert conversationDetails to MessageDetails
                    foreach (var conversationDetail in conversationDetails)
                    {
                        String date = (DateTime.Now.Subtract(conversationDetail.CreatedDate).Days) > 1 ?
                            String.Format("{0:HH:mm:ss}", conversationDetail.CreatedDate) :
                            String.Format("{0:dd/MM/yyyy HH:mm:ss}", conversationDetail.CreatedDate);
                        dynamic messageDetail = new JObject();
                        messageDetail.id = conversationDetail.ConversationDetailId;
                        messageDetail.Content = conversationDetail.Content;
                        messageDetail.Email = conversationDetail.User.Email;
                        messageDetail.Attachment = conversationDetail.Attachment;
                        messageDetail.CreatedDate = date;
                        conversationJson.Add(messageDetail);
                    }
                }
            }
            return conversationJson;
        }

        public void SearchByString(string searchString, ref IEnumerable<TreatmentHistory> treatments)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                treatments = treatments.Where(u => (!String.IsNullOrWhiteSpace(u.Doctor.FullName) && (u.Doctor.FullName.ToUpper().Contains(searchString.ToUpper()))));
            }
        }
    }
}
