﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using PagedList;
using Newtonsoft.Json.Linq;

namespace OMCS.Web.Controllers
{
    public class CommentController : BaseController
    {
        public ActionResult Index(int id, int? page)
        {
            var comments = _db.Comments.Where(c => c.DoctorId == id).OrderByDescending(u => u.PostedDate);
            var user = _db.Users.Where(u => u.UserId == id).SingleOrDefault();
            ViewBag.User = user;
            int pageSize = 4;
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

            Rating rating = _db.Ratings.Where(x =>
                (x.ObjectId == doctor.UserId) &&
                (x.RatingFor == RatingType.Doctor) &&
                (x.UserId == User.UserId)).FirstOrDefault();
            if (rating != null)
            {
                ViewBag.RatingPoint = rating.RatingPoint;
            }
            else
            {
                ViewBag.RatingPoint = 0;
            }
            ViewBag.User = _db.Users.Find(User.UserId);
            return PartialView("_Evaluate", comments);
        }

        [HttpPost]
        public JObject PostComment(string content, int doctorId)
        {
            //Check if doctor is logged user
            Comment comment = new Comment()
            {
                Content = content,
                PostedDate = DateTime.UtcNow,
                DoctorId = doctorId
            };
            if (doctorId != User.UserId)
            {
                comment.PatientId = User.UserId;
            }
            _db.Comments.Add(comment);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "success";
            return result;
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
            ViewBag.Email = doctor.Email;
            return PartialView("_RateQuickView");
        }

        [HttpPost]
        public JObject Rate(double ratingScore, int doctorId)
        {
            Doctor doctor = _db.Doctors.Find(doctorId);
            Rating rating = _db.Ratings.Where(x =>
                (x.ObjectId == doctorId) &&
                (x.RatingFor == RatingType.Doctor) &&
                (x.UserId == User.UserId)).FirstOrDefault();
            if (rating == null)
            {
                rating = new Rating
                {
                    RatingFor = RatingType.Doctor,
                    UserId = User.UserId,
                    ObjectId = doctor.UserId,
                    RatingPoint = ratingScore
                };
                _db.Ratings.Add(rating);
            }
            else
            {
                rating.RatingPoint = ratingScore;
            }
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "success";
            return result;
        }
    }
}
