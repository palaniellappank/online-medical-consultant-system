using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using PagedList;

namespace OMCS.Web.Controllers
{
    public class CommentController : BaseController
    {
        //
        // GET: /Comment/

        public ActionResult Index(int id, int? page)
        {
            var comments = _db.Comments.Where(c => c.DoctorId == id).OrderByDescending(u => u.CommentId);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("_Index", comments.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Comment/Details

        public ActionResult Details(int id)
        {
            User user = _db.Users.Find(id);
            Doctor doctor = _db.Doctors.Find(id);
            SpecialtyField field = _db.SpecialtyFields.FirstOrDefault(f => f.SpecialtyFieldId == doctor.SpecialtyFieldId);

            ViewBag.User = user;
            ViewBag.Doctor = doctor;
            ViewBag.SpecialtyField = field;

            return PartialView("_Details", user);
        }

        //
        // GET: /Comment/Evaluate

        public ActionResult Evaluate(int id)
        {
            IEnumerable<Comment> comments = _db.Comments.Where(c => c.DoctorId == id);
            User user = _db.Users.Find(id);

            ViewBag.PatientId = 7;
            ViewBag.DoctorId = id;
            ViewBag.User = user;

            return View(comments);
        }

        //
        // POST: /Comment/Post

        [HttpPost]
        public ActionResult Post(FormCollection form)
        {
            string content = form["Content"].ToString();
            int patientId = int.Parse(form["PatientId"]);
            int doctorId = int.Parse(form["DoctorId"]);

            try
            {
                Comment comment = new Comment()
                {
                    PatientId = patientId,
                    DoctorId = doctorId,
                    Content = content,
                    PostedDate = DateTime.UtcNow
                };

                _db.Comments.Add(comment);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Evaluate", "Comment", new { id = doctorId });
        }

        //
        // GET: /Comment/Rate

        public ActionResult Rate()
        {
            return PartialView("_Rate");
        }

        //
        // POST: /Comment/Rate

        [HttpPost]
        public ActionResult Rate(double rating, int doctorId)
        {
            try
            {
                Doctor doctor = _db.Doctors.Find(doctorId);
                if (doctor.Votes == 0)
                {
                    doctor.Rating = rating;
                }
                else
                {
                    double doubRates = (doctor.Rating * doctor.Votes + rating) / (doctor.Votes + 1);
                    String strRates = String.Format("{0:0.0}", doubRates);
                    doctor.Rating = double.Parse(strRates);
                }

                doctor.Votes++;
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Evaluate", "Comment", new { id = doctorId });
        }

        //
        // POST: /Comment/Post

        //[HttpPost]
        //public JsonResult Post(string content, int patientId, int doctorId)
        //{
        //    Debug.WriteLine(content);
        //    var comment = new Comment()
        //    {
        //        Content = content,
        //        PatientId = patientId,
        //        DoctorId = doctorId
        //    };
        //    _db.Comments.Add(comment);
        //    _db.SaveChanges();
        //    if (_db.SaveChanges() != 0)
        //    {
        //        return Json(true);
        //    }
        //    else
        //    {
        //        return Json(false);
        //    }
        //}

    }
}
