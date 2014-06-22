using OMCS.DAL.Model;
using OMCS.Web.Controllers;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
    [CustomAuthorize(Roles = "User, Doctor")]
    public class UserConversationController : BaseController
    {
        OMCSDBContext db = new OMCSDBContext();
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            ViewBag.Name = user.FullName;
            ViewBag.Username = user.Username;           
            return View();
        }

        public ActionResult Chat()
        {
            //var user = db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            //ViewBag.Name = user.FullName;
            //Debug.WriteLine(user.FullName);
            //ViewBag.Username = user.Username;
            return View();
        }

        public ActionResult ShowConversation()
        {
            return View();
        }

        public ActionResult ChatRoom()
        {
            //var user = db.Users.Where(u => u.UserId == User.UserId).SingleOrDefault();
            //ViewBag.Name = user.FullName;
            //ViewBag.Username = user.Username;          
            return View();
        }
    }
}