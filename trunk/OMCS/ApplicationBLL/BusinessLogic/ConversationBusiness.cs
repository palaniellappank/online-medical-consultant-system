using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using OMCS.DAL.Model;

namespace OMCS.BLL
{
    public class ConversationBusiness
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
                x => (x.Username == user.Username)).FirstOrDefault();
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
            foreach (var conversationDetail in conversationDetails) {
                conversationDetail.IsRead = true;
                _db.Entry(conversationDetail).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }
    }
}
