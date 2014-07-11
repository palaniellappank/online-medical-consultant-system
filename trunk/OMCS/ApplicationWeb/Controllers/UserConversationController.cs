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
        OMCSDBContext db = new OMCSDBContext();

        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            ViewBag.Name = user.FullName;
            ViewBag.Username = user.Username;
            return View();
        }

        public ActionResult Chat()
        {
            //var user = db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            //ViewBag.Name = user.FullName;
            //Debug.WriteLine(user.FullName);
            //ViewBag.Username = user.Username;
            return View();
        }

        public ActionResult ShowConversation()
        {
            return View();
        }

        public ActionResult ChatRoom()
        {
            //var user = db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            //ViewBag.Name = user.FullName;
            //ViewBag.Username = user.Username;          
            return View();
        }

        public JsonResult Upload(string fromUsername, string toUsername)
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
                    var fromUser = _db.Users.Where(x => x.Username.Equals(fromUsername)).FirstOrDefault();
                    var toUser = _db.Users.Where(x => x.Username.Equals(toUsername)).FirstOrDefault();
                    var doctor = _db.Doctors.Where(u => u.Username.Equals(fromUser.Username)).FirstOrDefault();
                    var patient = new Patient();
                    if (doctor == null)
                    {
                        doctor = _db.Doctors.Where(u => u.Username.Equals(toUser.Username)).FirstOrDefault();
                        patient = _db.Patients.Where(u => u.Username.Equals(fromUser.Username)).FirstOrDefault();
                    }
                    else
                    {
                        patient = _db.Patients.Where(u => u.Username.Equals(toUser.Username)).FirstOrDefault();
                    }

                    Conversation conversation = _db.Conversations.Where(x => (x.PatientId == patient.UserId && x.DoctorId == doctor.UserId)).OrderByDescending(x => x.DateConsulted).FirstOrDefault();

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