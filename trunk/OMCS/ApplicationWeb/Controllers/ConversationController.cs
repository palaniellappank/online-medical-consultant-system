using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using OMCS.BLL;
using Newtonsoft.Json.Linq;
using PagedList;

namespace OMCS.Web.Controllers
{
    public class ConversationController : BaseController
    {
        ConversationBusiness business;

        public ConversationController()
        {
            business = new ConversationBusiness(_db);
        }

        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            IEnumerable<TreatmentHistory> treatmentList = _db.TreatmentHistories.Where(t => (t.PatientId == User.UserId || t.MedicalProfile.PatientId == User.UserId)).OrderByDescending(x=>x.DateCreated).ToList();
            //var treatmentList = _db.TreatmentHistories.Where(t => (t.PatientId == User.UserId || t.MedicalProfile.PatientId == User.UserId)).ToList();
            //return View(treatmentList);            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            business.SearchByString(searchString, ref treatmentList);//Search UserName/Fullname by string
            ViewBag.CurrentFilter = searchString;           
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(treatmentList.ToPagedList(pageNumber, pageSize));
        }

        /*
            Get Conversation that belongs to a treatment
        */
        public ActionResult DoctorTreatmentConversation(int treatmentId)
        {
            var treatment = _db.TreatmentHistories.Find(treatmentId);
            User fromUser = treatment.Doctor;

            User toUser = treatment.Patient;
            if (toUser == null)
            {
                toUser = treatment.MedicalProfile.Patient;
            }
            dynamic fromUserJson = new JObject();
            fromUserJson.ProfilePicture = fromUser.ProfilePicture;
            fromUserJson.FullName = fromUser.FullName;
            fromUserJson.Email = fromUser.Email;
            dynamic toUserJson = new JObject();
            toUserJson.ProfilePicture = toUser.ProfilePicture;
            toUserJson.FullName = toUser.FullName;
            toUserJson.Email = toUser.Email;
            dynamic treatmentJson = new JObject();
            treatmentJson.TreatmentId = treatment.TreatmentHistoryId;
            treatmentJson.ConversationFromId = treatment.ConversationFromId;
            treatmentJson.ConversationToId = treatment.ConversationToId;
            ViewBag.messageList = business.GetMessageByTreatment(treatmentId);
            ViewBag.fromUser = fromUserJson;
            ViewBag.toUser = toUserJson;
            ViewBag.treatmentHistory = treatmentJson;
            return View("_DoctorTreatmentConversation");
        }

        /*
            Get Conversation that belongs to a treatment
        */
        public JArray GetMessageConversation(string fromEmail, string toEmail)
        {
            var messageList = business.GetMessageByConversation(fromEmail, toEmail);
            return messageList;
        }

        public void SaveTreatmentConversationMapping(int id, int conversationFromId, int conversationToId)
        {
            var treatment = _db.TreatmentHistories.Find(id);
            treatment.ConversationFromId = conversationFromId;
            treatment.ConversationToId = conversationToId;
            _db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}