﻿using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "User")]
    public class UserInfoController : BaseController
    {
        //PatientBusiness userBusiness;

        //public UserInfoController()
        //{
        //    userBusiness = new PatientBusiness(_db);
        //}

        public ActionResult Index()
        {
            var patient = _db.Patients.Where(pa => pa.UserId == User.UserId).SingleOrDefault();
            return View(patient);
        }

        public JObject Save(string name, string value, int pk)
        {
            var patient = _db.Patients.Where(pa => pa.UserId == User.UserId).SingleOrDefault();
            Type type = typeof(Patient);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if ("birthday".Equals(name) || "healthInsuranceIssued".Equals(name) || "healthInsuranceDateExpired".Equals(name))
            {
                DateTime datetime = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                pi.SetValue(patient, datetime);
            }
            else
            {
                pi.SetValue(patient, Convert.ChangeType(value, pi.PropertyType), null);
            }
            _db.SaveChanges();
            JObject result = new JObject();
            result.Add("status", "success");
            return result;
        }

        public ActionResult Uploadify()
        {
            var file = Request.Files["Filedata"];
            string savePath = Server.MapPath(@"~\Content\Image\ProfilePicture\" + file.FileName);
            file.SaveAs(savePath);
            string firstname = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().FirstName;
            string lastname = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().LastName;
            string password = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Password;
            DateTime createDate = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().CreatedDate;
            string gender = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Gender;
            DateTime? birthDate = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Birthday;
            string phone = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Phone;
            string primary = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().PrimaryAddress;
            string secondary = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().SecondaryAddress;
            string email = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Email;
            User patient = new User();
            patient.UserId = User.UserId;
            patient.FirstName = firstname;
            patient.LastName = lastname;
            patient.Password = password;
            patient.IsActive = true;
            patient.Phone = phone;
            patient.PrimaryAddress = primary;
            patient.SecondaryAddress = secondary;
            patient.CreatedDate = createDate;
            patient.Birthday = birthDate;
            patient.ProfilePicture = file.FileName;
            patient.Email = email;
            patient.Gender = gender;
            _db.Entry(patient).State = EntityState.Modified;
            _db.SaveChanges();
            return Json("Uploaded " + Request.Files.Count + " files");
        }
    }
}