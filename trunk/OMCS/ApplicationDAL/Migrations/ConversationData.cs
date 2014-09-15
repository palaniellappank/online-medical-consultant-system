namespace OMCS.DAL
{
    using OMCS.DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class ConversationData
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            Doctor bsNguyenVanA = _db.Doctors.Where(d => d.Email.Equals("vana@gmail.com")).FirstOrDefault();
            Patient sutran = _db.Patients.Where(p => p.Email.Equals("trannguyentiensu@gmail.com")).FirstOrDefault();
            Conversation suTranVsBacSiA = new Conversation
            {
                Doctor = bsNguyenVanA,
                Patient = sutran
            };

            ConversationDetail line1 = new ConversationDetail
            {
                Conversation = suTranVsBacSiA, Content = "Chào bác sĩ",
                User = sutran, CreatedDate = new DateTime(2014, 6, 1, 8, 20, 12)
            };

            ConversationDetail line2 = new ConversationDetail
            {
                Conversation = suTranVsBacSiA, Content = "Chào bạn",
                User = bsNguyenVanA,
                CreatedDate = new DateTime(2014, 6, 1, 8, 20, 40)
            };

            ConversationDetail line3 = new ConversationDetail
            {
                Conversation = suTranVsBacSiA,
                Content = "Em xin hỏi, nếu đau đầu mà tai và mắt cứ giật liên hồi, " +
                "sau mỗi lần giật lại càng đau đầu hơn, kèm theo sốt, thì nguyên nhân do đâu?",
                User = sutran, CreatedDate = new DateTime(2014, 6, 1, 8, 22, 12)
            };

            ConversationDetail line4 = new ConversationDetail
            {
                Conversation = suTranVsBacSiA,
                Content = "Đau đầu là một trong những triệu chứng thường gặp "+
                "nhất của nhiều bệnh, có nhiều nguyên nhân khác nhau gây đau đầu, "+
                "cảm giác đau ở một trong những điểm như: đau ở ngay phía trên 2 mắt, "+
                "2 tai, đau ở phía sau gáy, vùng trên của cổ.",
                User = bsNguyenVanA,
                CreatedDate = new DateTime(2014, 6, 1, 8, 25, 12)
            };

            ConversationDetail line5 = new ConversationDetail
            {
                Conversation = suTranVsBacSiA,
                Content = "Đau đầu là một trong những triệu chứng thường gặp " +
                "nhất của nhiều bệnh, có nhiều nguyên nhân khác nhau gây đau đầu, " +
                "cảm giác đau ở một trong những điểm như: đau ở ngay phía trên 2 mắt, " +
                "2 tai, đau ở phía sau gáy, vùng trên của cổ.",
                User = sutran,
                CreatedDate = new DateTime(2014, 6, 1, 8, 27, 12)
            };

            _db.ConversationDetails.Add(line1);
            _db.ConversationDetails.Add(line2);
            _db.ConversationDetails.Add(line3);
            _db.ConversationDetails.Add(line4);
            _db.ConversationDetails.Add(line5);
            _db.SaveChanges();
        }
    }
}
