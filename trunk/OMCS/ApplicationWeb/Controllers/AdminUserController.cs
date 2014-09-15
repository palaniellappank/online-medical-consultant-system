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
using Security.Models;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Validation;
using Security.DAL.Security;
using System.Threading;
using System.Diagnostics;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();
        private AdminUserBusiness business = new AdminUserBusiness();
        private AccountBusiness accBusiness = new AccountBusiness();
        //
        // GET: /AdminUser/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<User> users = db.Roles.Where(r => r.RoleName == "User").SelectMany(r => r.Users);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserSortParam = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
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

        //
        // GET: /AdminUser/Create

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        //
        // POST: /AdminUser/Create

        [HttpPost]
        public ActionResult Create(Patient user)
        {
            try
            {
                Role role = db.Roles.FirstOrDefault(r => r.RoleName == "User");
                user.Roles = new List<Role>() { role };
                user.CreatedDate = DateTime.UtcNow;
                user.ProfilePicture = "photo.jpg";
                user.IsActive = true;
                int getLastId = db.Users.Max(item => item.UserId);
                user.UserId = getLastId;               
                user.Password = accBusiness.GeneratePassword();
                db.Patients.Add(user);
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
                var subject = "Tạo tài khoản bệnh nhân";
                var body = "<html>" +
                                  "<body>" +
                                      "<h2>Hệ thống đã tạo cho bạn một tài khoản với các thông tin: </h2>" +
                                      "<p>Mật khẩu: " + user.Password + "</p>" +
                                  "</body>" +
                              "</html>";
                accBusiness.SendMail(user.Email, subject, body);
            });
            emailBackground.IsBackground = true;
            emailBackground.Start();
            return RedirectToAction("Index");
        }


        //
        // GET: /AdminUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            ViewBag.Roles = db.Roles.ToList();
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", user);
        }

        //
        // POST: /AdminUser/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    var filename = Request.Params["profile"];
                    string profile = Convert.ToString(filename);
                    user.ProfilePicture = profile;
                }
                else if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = HttpContext.Server.MapPath("~/Content/Image/ProfilePicture/" + fileName);
                    var dbPath = string.Format("/Content/Image/ProfilePicture/" + fileName);
                    file.SaveAs(path);
                    user.ProfilePicture = fileName;
                }
                //user.Roles.Add(role);
                user.IsActive = true;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", user);
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