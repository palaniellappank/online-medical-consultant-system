using OMCS.BLL;
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
using System.Threading;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Doctor")]
    public class DoctorUserController : BaseController
    {
        private AdminUserBusiness business = new AdminUserBusiness();
        private MedicalProfileBusiness medicalProfileBusiness = new MedicalProfileBusiness();
        private AccountBusiness accBusiness = new AccountBusiness();

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
                var email = Request.Params["Email"];
                string emailPatient = Convert.ToString(email);
                patient.Email = emailPatient;
                var first = Request.Params["FirstName"];
                string firstname = Convert.ToString(first);
                patient.FirstName = firstname;
                var last = Request.Params["LastName"];
                string lastname = Convert.ToString(last);
                patient.LastName = lastname;
                var ethnicity = Request.Params["Ethnicity"];
                string ethnicityP = Convert.ToString(ethnicity);
                patient.Ethnicity = ethnicityP;
                var nationality = Request.Params["Nationality"];
                string nationalityP = Convert.ToString(nationality);
                patient.Nationality = nationalityP;
                patient.IsActive = true;
                patient.Password = accBusiness.GeneratePassword();
                _db.Users.Add(patient);
                _db.SaveChanges();
                int getLastId = _db.Users.Max(item => item.UserId);
                PersonalHealthRecord personal = new PersonalHealthRecord();
                personal.PatientId = getLastId;
                var height = Request.Params["height"];
                if (height == "")
                {
                    personal.Height = 0;
                }
                else
                {
                    double heightPatient = double.Parse(height);
                    personal.Height = heightPatient;
                }

                var weight = Request.Params["weight"];
                if (weight == "")
                {
                    personal.Weight = 0;
                }
                else
                {
                    double weightPatient = double.Parse(weight);
                    personal.Height = weightPatient;
                }


                var eye = Request.Params["eye"];
                string eyeColor = eye.ToString();

                var hair = Request.Params["hair"];
                string hairColor = hair.ToString();

                var blood = Request.Params["blood"];
                string bloodType = blood.ToString();

                var alcoholWeek = Request.Params["alcoholweek"];
                if (alcoholWeek == "")
                {
                    personal.AlcoholPerWeek = 0;
                }
                else
                {
                    double alcoholPerWeek = double.Parse(alcoholWeek);
                    personal.AlcoholPerWeek = alcoholPerWeek;
                }

                var alcoholYear = Request.Params["alcoholyear"];
                if (alcoholYear == "")
                {
                    personal.AlcoholNumOfYear = 0;
                }
                else
                {
                    int alcoholNumberOfYear = Convert.ToInt32(alcoholYear);
                    personal.AlcoholNumOfYear = alcoholNumberOfYear;
                }

                var smokeYear = Request.Params["smokeyear"];
                if (smokeYear == "")
                {
                    personal.SmokePackPerWeek = 0;
                }
                else
                {
                    int smokeNumberOfYear = Convert.ToInt32(smokeYear);
                    personal.SmokeNumOfYear = smokeNumberOfYear;
                }

                var smokeWeek = Request.Params["smokeweek"];
                if (smokeWeek == "")
                {
                    personal.SmokePackPerWeek = 0;
                }
                else
                {
                    double smokePerWeek = double.Parse(smokeWeek);
                    personal.SmokePackPerWeek = smokePerWeek;
                }

                var sport = Request.Params["sport"];
                string sportName = sport.ToString();

                var sportWeek = Request.Params["sportweek"];
                if (sportWeek == "")
                {
                    personal.SportPerWeek = 0;
                }
                else
                {
                    int sportPerWeek = Convert.ToInt32(sportWeek);
                    personal.SportPerWeek = sportPerWeek;
                }

                var exercise = Request.Params["exercise"];
                string exerciseType = exercise.ToString();

                var exerciseWeek = Request.Params["exerciseweek"];
                if (exerciseWeek == "")
                {
                    personal.ExercisePerWeek = 0;
                }
                else
                {
                    int exercisePerWeek = Convert.ToInt32(exerciseWeek);
                    personal.ExercisePerWeek = exercisePerWeek;
                }           
                _db.PersonalHealthRecords.Add(personal);
                _db.SaveChanges();
                Patient newPatient = new Patient();
                newPatient.UserId = getLastId;
                _db.Patients.Add(newPatient);
                _db.SaveChanges();
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
            // Create thread to send mail (background)   
            Thread emailBackground = new Thread(delegate()
            {
                var subject = "Tạo tài khoản bệnh nhân";
                var body = "<html>" +
                                  "<body>" +
                                      "<h2>Hệ thống đã tạo cho bạn một tài khoản với các thông tin: </h2>" +                                      
                                      "<p>Mật khẩu: " + patient.Password + "</p>" +
                                  "</body>" +
                              "</html>";
                accBusiness.SendMail(patient.Email, subject, body);
            });
            emailBackground.IsBackground = true;
            emailBackground.Start();
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
            var ethnicity = Request.Params["Ethnicity"];
            string ethnicityP = Convert.ToString(ethnicity);
            patient.Ethnicity = ethnicityP;
            var nationality = Request.Params["Nationality"];
            string nationalityP = Convert.ToString(nationality);
            patient.Nationality = nationalityP;
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