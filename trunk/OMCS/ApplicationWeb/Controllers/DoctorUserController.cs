﻿using OMCS.BLL;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using OMCS.Web.DTO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Validation;
using System.IO;
using System.Data;
using System.Text;
using WebMatrix.WebData;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Doctor")]
    public class DoctorUserController : BaseController
    {
        private AdminUserBusiness business = new AdminUserBusiness();
        private MedicalProfileBusiness medicalProfileBusiness = new MedicalProfileBusiness();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<User> users = _db.Patients.ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserSortParam = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.IsActiveParam = sortOrder == "Active" ? "Active_desc" : "Active";
            ViewBag.NameSortParam = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.PhoneSortParam = sortOrder == "Phone" ? "Phone_desc" : "Phone";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            business.SearchByString(searchString, ref users);//Search UserName/Fullname by string
            business.CheckSortOrder(sortOrder, ref users);// Check sort order to sort with the corresponding column

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult View(int id)
        {
            var patient = _db.Patients.Find(id);
            var personalHealthRecord = _db.PersonalHealthRecords.Find(id);
            var medicalProfiles = _db.MedicalProfiles.Where(mp => mp.PatientId == id).ToList();
            var medicalProfileTemplates = _db.MedicalProfileTemplates.ToList();
            SelectList medicalProfileTemplateList = new SelectList(medicalProfileTemplates,
                "MedicalProfileTemplateId", "MedicalProfileTemplateName",
                medicalProfileTemplates.First());
            PatientInformation PatientInformation = new PatientInformation
            {
                Patient = patient,
                PersonalHealthRecord = personalHealthRecord,
                MedicalProfiles = medicalProfiles
            };
            ViewBag.medicalProfileTemplateList = medicalProfileTemplateList;
            return PartialView("_View", PatientInformation);
        }

        public ActionResult UpdateMedicalProfile(int id, int medicalProfileTemplateId)
        {
            var str = medicalProfileBusiness.UpdateMedicalProfile(id, medicalProfileTemplateId);
            ViewBag.formInJson = str;
            ViewBag.patientId = id;
            ViewBag.medicalProfileTemplateId = medicalProfileTemplateId;
            ViewBag.medicalProfileName = _db.MedicalProfileTemplates.Find(medicalProfileTemplateId).MedicalProfileTemplateName;

            var medicalProfile = _db.MedicalProfiles.Where(
                mp => ((mp.PatientId == id) &&
                    (mp.MedicalProfileTemplateId == medicalProfileTemplateId))
            ).FirstOrDefault();
            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateMedicalProfile(FormCollection formCollection)
        {
            medicalProfileBusiness.UpdateMedicalProfileForPatient(formCollection);
            return View();
        }

        public ActionResult CreatePatient()
        {
            return PartialView("CreatePatient");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreatePatient(Patient patient)
        {
            try
            {
                Role role = _db.Roles.FirstOrDefault(r => r.RoleName == "User");
                patient.Roles = new List<Role>();
                patient.Roles.Add(role);
                patient.CreatedDate = DateTime.UtcNow;
                patient.ProfilePicture = "photo.jpg";
                var username = Request.Params["Username"];
                string userN = Convert.ToString(username);
                patient.Username = userN;
                var email = Request.Params["Email"];
                string emailPatient = Convert.ToString(email);
                patient.Email = emailPatient;
                var first = Request.Params["FirstName"];
                string firstname = Convert.ToString(first);
                patient.FirstName = firstname;
                var last = Request.Params["LastName"];
                string lastname = Convert.ToString(last);
                patient.LastName = lastname;
                var pass = Request.Params["Password"];
                string password = Convert.ToString(pass);
                patient.Password = password;
                patient.IsActive = true;
                _db.Users.Add(patient);
                _db.SaveChanges();
                int getLastId = _db.Users.Max(item => item.UserId);

                var height = Request.Params["height"];
                double heightPatient = double.Parse(height);

                var weight = Request.Params["weight"];
                double weightPatient = double.Parse(weight);

                var eye = Request.Params["eye"];
                string eyeColor = eye.ToString();

                var hair = Request.Params["hair"];
                string hairColor = hair.ToString();

                var blood = Request.Params["blood"];
                string bloodType = blood.ToString();

                var alcoholWeek = Request.Params["alcoholweek"];
                double alcoholPerWeek = double.Parse(alcoholWeek);

                var alcoholYear = Request.Params["alcoholyear"];
                int alcoholNumberOfYear = Convert.ToInt32(alcoholYear);

                var smokeYear = Request.Params["smokeyear"];
                int smokeNumberOfYear = Convert.ToInt32(smokeYear);

                var smokeWeek = Request.Params["smokeweek"];
                double smokePerWeek = double.Parse(smokeWeek);

                var sport = Request.Params["sport"];
                string sportName = sport.ToString();

                var sportWeek = Request.Params["sportweek"];
                int sportPerWeek = Convert.ToInt32(sportWeek);

                var exercise = Request.Params["exercise"];
                string exerciseType = exercise.ToString();

                var exerciseWeek = Request.Params["exerciseweek"];
                int exercisePerWeek = Convert.ToInt32(exerciseWeek);

                PersonalHealthRecord personal = new PersonalHealthRecord()
                {
                    PatientId = getLastId,
                    Height = heightPatient,
                    Weight = weightPatient,
                    EyeColor = eyeColor,
                    HairColor = hairColor,
                    BloodType = bloodType,
                    AlcoholPerWeek = alcoholPerWeek,
                    AlcoholNumOfYear = alcoholNumberOfYear,
                    IsBeer = true,
                    SmokeNumOfYear = smokeNumberOfYear,
                    SmokePackPerWeek = smokePerWeek,
                    SportName = sportName,
                    SportPerWeek = sportPerWeek,
                    ExerciseType = exerciseType,
                    ExercisePerWeek = exercisePerWeek
                };
                _db.PersonalHealthRecords.Add(personal);
                _db.SaveChanges();
                Patient newPatient = new Patient();
                newPatient.UserId = getLastId;
                _db.Patients.Add(newPatient);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditPatient(int id = 0)
        {
            var patient = _db.Patients.Find(id);
            var personalHealthRecord = _db.PersonalHealthRecords.Find(id);
            PatientInformation PatientInformation = new PatientInformation
            {
                Patient = patient,
                PersonalHealthRecord = personalHealthRecord,
            };
            return PartialView("EditPatient", PatientInformation);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditPatient(Patient patient, HttpPostedFileBase file)
        {
            if (file == null)
            {
                var filename = Request.Params["profile"];
                string profile = Convert.ToString(filename);
                patient.ProfilePicture = profile;
            }
            else if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = HttpContext.Server.MapPath("~/Content/Image/ProfilePicture/" + fileName);
                var dbPath = string.Format("/Content/Image/ProfilePicture/" + fileName);
                file.SaveAs(path);
                patient.ProfilePicture = fileName;
            }

            var first = Request.Params["FirstName"];
            string firstname = Convert.ToString(first);
            patient.FirstName = firstname;
            var last = Request.Params["LastName"];
            string lastname = Convert.ToString(last);
            patient.LastName = lastname;
            var pass = Request.Params["Password"];
            string password = Convert.ToString(pass);
            patient.Password = password;
            patient.IsActive = true;
            _db.Entry(patient).State = EntityState.Modified;
            _db.SaveChanges();

            var id = Request.Params["patientid"];
            int patientid = Convert.ToInt32(id);

            var height = Request.Params["height"];
            double heightPatient = double.Parse(height);

            var weight = Request.Params["weight"];
            double weightPatient = double.Parse(weight);

            var eye = Request.Params["eye"];
            string eyeColor = eye.ToString();

            var hair = Request.Params["hair"];
            string hairColor = hair.ToString();

            var blood = Request.Params["blood"];
            string bloodType = blood.ToString();

            var alcoholWeek = Request.Params["alcoholweek"];
            double alcoholPerWeek = double.Parse(alcoholWeek);

            var alcoholYear = Request.Params["alcoholyear"];
            int alcoholNumberOfYear = Convert.ToInt32(alcoholYear);

            //var isBeer = Request.Params["beer"];
            //bool beer = bool.Parse(isBeer);

            var smokeYear = Request.Params["smokeyear"];
            int smokeNumberOfYear = Convert.ToInt32(smokeYear);

            var smokeWeek = Request.Params["smokeweek"];
            double smokePerWeek = double.Parse(smokeWeek);

            var sport = Request.Params["sport"];
            string sportName = sport.ToString();

            var sportWeek = Request.Params["sportweek"];
            int sportPerWeek = Convert.ToInt32(sportWeek);

            var exercise = Request.Params["exercise"];
            string exerciseType = exercise.ToString();

            var exerciseWeek = Request.Params["exerciseweek"];
            int exercisePerWeek = Convert.ToInt32(exerciseWeek);
            PersonalHealthRecord personal = new PersonalHealthRecord()
            {
                PatientId = patientid,
                Height = heightPatient,
                Weight = weightPatient,
                EyeColor = eyeColor,
                HairColor = hairColor,
                BloodType = bloodType,
                AlcoholPerWeek = alcoholPerWeek,
                AlcoholNumOfYear = alcoholNumberOfYear,
                IsBeer = true,
                SmokeNumOfYear = smokeNumberOfYear,
                SmokePackPerWeek = smokePerWeek,
                SportName = sportName,
                SportPerWeek = sportPerWeek,
                ExerciseType = exerciseType,
                ExercisePerWeek = exercisePerWeek
            };
            _db.Entry(personal).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /AdminUser/CheckExistUsername
        [HttpPost]
        public JsonResult CheckExistUsername(string userName, int id = 0)
        {
            var user = _db.Patients.FirstOrDefault(u => u.Username == userName);
            if (user != null && id != user.UserId)
            {
                return new JsonResult { Data = false };
            }
            return new JsonResult { Data = true };
        }

        //
        // POST: /AdminUser/CheckExistEmail
        [HttpPost]
        public JsonResult CheckExistEmail(string email, int id = 0)
        {
            var user = _db.Patients.FirstOrDefault(u => u.Email == email);
            if (user != null && id != user.UserId)
            {
                return new JsonResult { Data = false };
            }
            return new JsonResult { Data = true };
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }


}