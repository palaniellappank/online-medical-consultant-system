using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles= "Doctor")]
    public class DoctorCommentController : BaseController
    {
        public ActionResult Index()
        {
            Doctor doctor = _db.Doctors.Find(User.UserId);
            IEnumerable<Comment> comments = _db.Comments.Where(c => c.DoctorId == doctor.UserId);

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

            return View();
        }

    }
}