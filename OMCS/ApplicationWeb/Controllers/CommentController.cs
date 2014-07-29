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
        public ActionResult Index(int id, int? page)
        {
            var comments = _db.Comments.Where(c => c.DoctorId == id).OrderByDescending(u => u.CommentId);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("_Index", comments.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
            User user = _db.Users.Find(id);
            Doctor doctor = _db.Doctors.Find(id);
            SpecialtyField field = _db.SpecialtyFields.FirstOrDefault(f => f.SpecialtyFieldId == doctor.SpecialtyFieldId);

            ViewBag.User = user;
            ViewBag.Doctor = doctor;
            ViewBag.SpecialtyField = field;

            List<Rating> ratings = _db.Ratings.Where(
                x => (x.RatingFor == RatingType.Doctor) && (x.ObjectId == doctor.UserId)).ToList();
            ViewBag.RatingCount = ratings.Count;
            double ratingPoint = 0;
            if (ratings.Count > 0)
            {
                ratingPoint = ratings.Sum(x => x.RatingPoint) / ratings.Count;
            }
            ViewBag.DoctorId = doctor.UserId;
            ViewBag.RatingPoint = ratingPoint;
            ViewBag.RatingCount = ratings.Count;

            return PartialView("_Details", user);
        }

        public ActionResult Evaluate(int id)
        {
            Doctor doctor = _db.Doctors.Find(id);
            IEnumerable<Comment> comments = _db.Comments.Where(c => c.DoctorId == doctor.UserId);
            ViewBag.DoctorId = doctor.UserId;
            return PartialView("_Evaluate", comments);
        }

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

        public ActionResult Rate()
        {
            return PartialView("_Rate");
        }

        public ActionResult RateQuickView(string doctorEmail)
        {
            Doctor doctor = _db.Doctors.Where(x => x.Email.Equals(doctorEmail)).SingleOrDefault();
            List<Rating> ratings = _db.Ratings.Where(
                x => (x.RatingFor == RatingType.Doctor) && (x.ObjectId == doctor.UserId)).ToList();
            ViewBag.RatingCount = ratings.Count;
            double ratingPoint = 0;
            if (ratings.Count > 0)
            {
                ratingPoint = ratings.Sum(x => x.RatingPoint) / ratings.Count;
            }
            ViewBag.DoctorId = doctor.UserId;
            ViewBag.RatingPoint = ratingPoint;
            ViewBag.RatingCount = ratings.Count;
            return PartialView("_RateQuickView");
        }

        [HttpPost]
        public ActionResult Rate(double ratingScore, int doctorId)
        {
            try
            {
                Doctor doctor = _db.Doctors.Find(doctorId);
                Rating rating = new Rating {
                    RatingFor = RatingType.Doctor,
                    UserId = User.UserId,
                    ObjectId = doctor.UserId
                };
                _db.Ratings.Add(rating);
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
