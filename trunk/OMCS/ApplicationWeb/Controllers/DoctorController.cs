using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles= "Doctor")]
    public class DoctorController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.recentMedicalProfiles = _db.MedicalProfiles.Where(
                x => x.Doctor.UserId == User.UserId).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.recentComments = _db.Comments.Where(
                x => x.DoctorId == User.UserId).Take(5).OrderByDescending(x => x.PostedDate).ToList();
            ViewBag.recentMessage = _db.Conversations.Where(c => c.DoctorId == User.UserId).OrderByDescending(x => x.DateConsulted).ToList();
            ViewBag.countMessage = _db.Conversations.Where(c => (c.IsDoctorRead == false) && (c.DoctorId == User.UserId)).Count();
            ViewBag.doctorId = _db.Doctors.Where(d => d.UserId == User.UserId).SingleOrDefault();           
            return View();
        }

    }
}