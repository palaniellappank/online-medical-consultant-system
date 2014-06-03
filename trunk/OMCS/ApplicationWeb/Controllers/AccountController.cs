using Security.DAL;
using Security.DAL.Security;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using System.Web.Script.Serialization;
using System.Web.Security;
using Newtonsoft.Json;
using System.Diagnostics;
namespace Security.Controllers
{
    public class AccountController : Controller
    {
        OMCSDBContext db = new OMCSDBContext();
        
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var roles=user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.roles = roles;

                   string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                            user.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(15),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    if(roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (roles.Contains("HospitalAdmin"))
                    {
                        return RedirectToAction("Index", "HospitalAdmin");
                    }
                    else if (roles.Contains("Doctor"))
                    {
                        return RedirectToAction("Index", "Doctor");
                    }
                    else if (roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /UserTemp/Create

        [HttpPost]
        public ActionResult Register(User user)
        {
            Debug.WriteLine("sdfd");
            Debug.WriteLine(user.Email);
            Debug.WriteLine(user.FullName);
            user.CreatedDate = DateTime.UtcNow;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Register");
        }

        public bool CheckUsername(string data)
        {
            Debug.WriteLine(data);
            var username = (from user in db.Users 
                            where user.Username.Equals(data,StringComparison.InvariantCultureIgnoreCase)
                            select user).FirstOrDefault();
            if (username != null) return false;
            else return true;
        }
        public bool CheckEmail(string data)
        {
            Debug.WriteLine(data);
            var email = (from user in db.Users
                         where user.Email.Equals(data, StringComparison.InvariantCultureIgnoreCase)
                         select user).FirstOrDefault();
            if (email != null) return false;
            else return true;
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}