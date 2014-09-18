using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using System.IO;
using PagedList;
using OMCS.BLL;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading;
using Security.DAL.Security;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminDoctorController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();
        private AdminUserBusiness business = new AdminUserBusiness();
        private AdminDoctorBusiness docBusiness = new AdminDoctorBusiness();
        private AccountBusiness accBusiness = new AccountBusiness();
        //
        // GET: /AdminDoctor/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Doctor> users = db.Doctors.Where(d => d.UserId != 0).ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserSortParam = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.SpecialitySortParam = sortOrder == "Speciality" ? "Speciality_desc" : "Speciality";
            ViewBag.IsActiveParam = sortOrder == "Active" ? "Active_desc" : "Active";
            ViewBag.NameSortParam = sortOrder == "Name" ? "Name_desc" : "Name";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            docBusiness.SearchByString(searchString, ref users);//Search UserName/Fullname by string
            docBusiness.CheckSortOrder(sortOrder, ref users);// Check sort order to sort with the corresponding column

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /AdminDoctor/Create

        public ActionResult Create()
        {
            var specialtyFields = db.SpecialtyFields.ToList();
            ViewBag.SpecialtyFieldId = specialtyFields;
            return PartialView("Create");
        }

        //
        // POST: /AdminDoctor/Create

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            try
            {
                Role role = db.Roles.FirstOrDefault(r => r.RoleName == "Doctor");
                doctor.Roles = new List<Role>();
                doctor.Roles.Add(role);
                doctor.CreatedDate = DateTime.UtcNow;
                doctor.ProfilePicture = "photo.jpg";
                doctor.IsActive = true;               
                var email = Request.Params["Email"];
                string emailPatient = Convert.ToString(email);
                doctor.Email = emailPatient;
                doctor.Password = accBusiness.GeneratePassword();
                var first = Request.Params["FirstName"];
                string firstname = Convert.ToString(first);
                doctor.FirstName = firstname;
                var last = Request.Params["LastName"];
                string lastname = Convert.ToString(last);
                doctor.LastName = lastname;
                int getLastId = db.Users.Max(item => item.UserId);
                var specialtyFieldId = Request.Params["dropdownlist"];
                int specialty = Convert.ToInt32(specialtyFieldId);
                doctor.UserId = getLastId;
                doctor.SpecialtyFieldId = specialty;
                db.Doctors.Add(doctor);
                db.SaveChanges();
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
            Thread emailBackground = new Thread(delegate()
            {
                var subject = "Tạo tài khoản bác sĩ";
                var body = "<html>" +
                                  "<body>" +
                                      "<h2>Hệ thống đã tạo cho bạn một tài khoản với các thông tin: </h2>" +                                     
                                      "<p>Mật khẩu: " + doctor.Password + "</p>" +
                                  "</body>" +
                              "</html>";
                accBusiness.SendMail(doctor.Email, subject, body);
            });
            emailBackground.IsBackground = true;
            emailBackground.Start();
            return RedirectToAction("Index");
        }

        //
        // GET: /AdminDoctor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Doctor doctor = db.Doctors.Find(id);
            ViewBag.Roles = db.Roles.ToList();
            var speciality = db.SpecialtyFields.ToList();
            ViewBag.SpecialtyFieldId = new SelectList(speciality, "SpecialtyFieldId", "Name", doctor.SpecialtyFieldId);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", doctor);
        }

        //
        // POST: /AdminDoctor/Edit/5

        [HttpPost]
        public ActionResult Edit(Doctor doctor, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    var filename = Request.Params["profile"];
                    string profile = Convert.ToString(filename);
                    doctor.ProfilePicture = profile;
                }
                else if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = HttpContext.Server.MapPath("~/Content/Image/ProfilePicture/" + fileName);
                    var dbPath = string.Format("/Content/Image/ProfilePicture/" + fileName);
                    file.SaveAs(path);
                    doctor.ProfilePicture = fileName;
                }
                var first = Request.Params["FirstName"];
                string firstname = Convert.ToString(first);
                doctor.FirstName = firstname;
                var last = Request.Params["LastName"];
                string lastname = Convert.ToString(last);
                doctor.LastName = lastname;
                doctor.IsActive = true;
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return PartialView("Edit", doctor);
        }

        //
        // GET: /AdminUser/Deactive
        public ActionResult Deactivate(int id)
        {
            var user = db.Users.Find(id);
            user.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /AdminUser/Activate
        public ActionResult Activate(int id)
        {
            var user = db.Users.Find(id);
            user.IsActive = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // POST: /AdminUser/CheckExistEmail
        [HttpPost]
        public JsonResult CheckExistEmail(string email, int id = 0)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && id != user.UserId)
            {
                return new JsonResult { Data = false };
            }
            return new JsonResult { Data = true };
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}