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
    public class ConversationBusiness : BaseBusiness
    {
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
    }
}
