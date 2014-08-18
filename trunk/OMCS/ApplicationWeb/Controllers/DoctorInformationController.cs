using OMCS.DAL.Model;
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
    [CustomAuthorize(Roles = "Doctor")]
    public class DoctorInformationController : BaseController
    {
        //
        // GET: /DoctorInformation/

        public ActionResult Index()
        {
            Doctor doctor = _db.Doctors.Where(d => d.UserId == User.UserId).SingleOrDefault();
            return View(doctor);
        }

        public JObject Save(string name, string value, int pk)
        {
            var doctor = _db.Doctors.Where(d => d.UserId == User.UserId).SingleOrDefault();
            Type type = typeof(Doctor);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if ("birthday".Equals(name))
            {
                DateTime datetime = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                pi.SetValue(doctor, datetime);
            }
            else
            {
                pi.SetValue(doctor, Convert.ChangeType(value, pi.PropertyType), null);
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
            User doctor = new User();
            doctor.UserId = User.UserId;
            doctor.FirstName = firstname;
            doctor.LastName = lastname;
            doctor.Password = password;
            doctor.IsActive = true;
            doctor.Phone = phone;
            doctor.PrimaryAddress = primary;
            doctor.SecondaryAddress = secondary;
            doctor.CreatedDate = createDate;
            doctor.Birthday = birthDate;
            doctor.ProfilePicture = file.FileName;
            doctor.Email = email;
            doctor.Gender = gender;
            _db.Entry(doctor).State = EntityState.Modified;
            _db.SaveChanges();
            return Content(Url.Content(@"~\Content\Image\ProfilePicture\" + file.FileName));
        }

        public ActionResult ChangePassword(int id = 0)
        {
            User user = _db.Users.Find(id);
            ViewBag.Roles = _db.Roles.ToList();
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("ChangePassword", user);
        }


        [HttpPost]
        public ActionResult ChangePassword(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                var pass = Request.Params["NewPassword"];
                string password = Convert.ToString(pass);
                user.Password = password;
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("ChangePassword", user);
        }       
    }
}
