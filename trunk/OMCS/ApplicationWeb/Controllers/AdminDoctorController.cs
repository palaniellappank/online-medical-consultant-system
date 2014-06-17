﻿using System;
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

namespace MvcApplication1.Controllers
{
    public class AdminDoctorController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();
        private AdminUserBusiness business = new AdminUserBusiness();

        //
        // GET: /AdminDoctor/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<User> users = db.Roles.Where(r => r.RoleName == "Doctor").SelectMany(r => r.Users);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserSortParam = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
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
            business.SearchByString(searchString, ref users);//Search UserName/Fullname by string
            business.CheckSortOrder(sortOrder, ref users);// Check sort order to sort with the corresponding column

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /AdminDoctor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminDoctor/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                Role role = db.Roles.FirstOrDefault(r => r.RoleName == "Doctor");
                user.Roles = new List<Role>();
                user.Roles.Add(role);
                user.CreatedDate = DateTime.Now;
                user.ProfilePicture = "/Content/ProfilePicture/anonymous-avatar.jpg";
                user.IsActive = false;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);

        }

        //
        // GET: /AdminDoctor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /AdminDoctor/Edit/5

        [HttpPost]
        public ActionResult Edit(User user, HttpPostedFileBase file, int roleId)
        {
            var role = db.Roles.Find(roleId);
            user.Roles = new List<Role>();
            try
            {
                if (file.ContentLength > 0 && file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = HttpContext.Server.MapPath("~/Content/ProfilePicture/" + fileName);
                    var dbPath = string.Format("/Content/ProfilePicture/" + fileName);
                    file.SaveAs(path);
                    user.ProfilePicture = dbPath;
                    user.Roles.Add(role);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (NullReferenceException ex)
            {
                user.Roles.Add(role);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
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
        // POST: /AdminUser/CheckUserNameExist
        [HttpPost]
        public JsonResult CheckUserNameExist(string userName, FormCollection form)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == userName);
            return Json(user == null);
        }

        //
        // POST: /AdminUser/CheckEmailExist
        [HttpPost]
        public JsonResult CheckEmailExist(string email)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            return Json(user == null);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}