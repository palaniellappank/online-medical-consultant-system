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

            List<Conversation> conversations = _db.Conversations.Where(
                    x => (x.DoctorId == user.UserId)
                    || (x.PatientId == user.UserId)).ToList();

            foreach (var conversation in conversations)
            {
                var lastMessage = _db.ConversationDetails.Where(
                    x => (x.ConversationId == conversation.ConversationId)
                    && (x.IsRead == false))
                    .OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                if (lastMessage != null) countMessageUnRead++;
            }
            return countMessageUnRead;
        }

        public void MarkConversationAsRead(Conversation conversation)
        {
            conversation.IsRead = true;
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
