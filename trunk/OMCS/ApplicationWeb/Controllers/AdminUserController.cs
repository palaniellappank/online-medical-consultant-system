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

namespace OMCS.Web.Controllers
{
    public class AdminUserController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();
        private AdminUserBusiness business = new AdminUserBusiness();

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
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                Role role = db.Roles.FirstOrDefault(r => r.RoleName == "User");
                user.Roles = new List<Role>();
                user.Roles.Add(role);
                user.CreatedDate = DateTime.UtcNow;
                user.ProfilePicture = "photo.jpg";
                user.IsActive = true;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_Create", user);

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
        public ActionResult Edit(User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = HttpContext.Server.MapPath("~/Content/Image/ProfilePicture/" + fileName);
                    var dbPath = string.Format("/Content/Image/ProfilePicture/" + fileName);
                    file.SaveAs(path);
                    user.ProfilePicture = fileName;
                }
                catch (NullReferenceException ex)
                {

                }
                finally
                {
                    //user.Roles.Add(role);
                    user.IsActive = true;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
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
        // POST: /AdminUser/CheckExistUsername
        [HttpPost]
        public JsonResult CheckExistUsername(string userName, int id = 0)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == userName);
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