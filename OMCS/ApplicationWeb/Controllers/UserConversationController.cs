using OMCS.DAL.Model;
using OMCS.Web.Controllers;
using Security.DAL.Security;
using SignalRChat.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
    [CustomAuthorize(Roles = "User, Doctor")]
    public class UserConversationController : BaseController
    {
        public ActionResult Index()
        {
            var user = _db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            ViewBag.SpecialtyFields = _db.SpecialtyFields.ToList();
            ViewBag.Name = user.FullName;
            ViewBag.Email = user.Email;
            return View();
        }

        public JsonResult Upload(string fromEmail, string toEmail)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file                
                //Use the following properties to get file's name, size and MIMEType
                if (file != null)
                {
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;
                    //To save file, use SaveAs method
                    file.SaveAs(Server.MapPath("~/Content/Upload/") + fileName); //File will be saved in application root                                         
                    var fromUser = _db.Users.Where(x => x.Email.Equals(fromEmail)).FirstOrDefault();
                    var toUser = _db.Users.Where(x => x.Email.Equals(toEmail)).FirstOrDefault();
                    var doctor = _db.Doctors.Where(u => u.Email.Equals(fromUser.Email)).FirstOrDefault();
                    var patient = new Patient();
                    if (doctor == null)
                    {
                        doctor = _db.Doctors.Where(u => u.Email.Equals(toUser.Email)).FirstOrDefault();
                        patient = _db.Patients.Where(u => u.Email.Equals(fromUser.Email)).FirstOrDefault();
                    }
                    else
                    {
                        patient = _db.Patients.Where(u => u.Email.Equals(toUser.Email)).FirstOrDefault();
                    }

                    Conversation conversation = _db.Conversations.Where(x => (x.PatientId == patient.UserId && x.DoctorId == doctor.UserId)).FirstOrDefault();

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
                        conversation.LatestContentFromPatient = fileName;
                        conversation.IsDoctorRead = false;
                    }
                    else
                    {
                        conversation.LatestTimeFromDoctor = DateTime.Now;
                        conversation.LatestContentFromDoctor = fileName;
                        conversation.IsPatientRead = false;
                    }
                    String date = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
                    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
                    ConversationDetail conversationDetail = new ConversationDetail
                    {
                        UserId = fromUser.UserId,
                        Attachment = fileName,
                        Conversation = conversation,
                        CreatedDate = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal),
                        IsRead = false
                    };
                    _db.ConversationDetails.Add(conversationDetail);
                    _db.SaveChanges();
                }

            }
            return Json("Đã upload " + Request.Files.Count + " dữ liệu");
        }       
    }
}