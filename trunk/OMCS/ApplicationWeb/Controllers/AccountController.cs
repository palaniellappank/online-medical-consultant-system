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
using Recaptcha.Web.Mvc;
using Recaptcha.Web;

namespace OMCS.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Where(u => u.Username == model.Username && u.Password == model.Password && u.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.Username = user.Username;
                    serializeModel.roles = roles;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                            user.Email,
                             DateTime.Now,
                             DateTime.Now.AddDays(1),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    if (roles.Contains("Admin"))
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
                        return RedirectToAction("Index", "UserInfo");
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var recaptchaHelper = this.GetRecaptchaVerificationHelper();

                if (String.IsNullOrEmpty(recaptchaHelper.Response))
                {
                    ModelState.AddModelError("", "Captcha answer cannot be empty");                    
                    return View(user);
                }

                var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

                if (recaptchaResult != RecaptchaVerificationResult.Success)
                {
                    ModelState.AddModelError("", "Incorrect captcha answer");                    
                    return View(user);
                }

                // Attempt to register the user
                try
                {
                    user.CreatedDate = DateTime.UtcNow;
                    //db.Patients.Add((User)user);
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("Register");
                }
                catch (MembershipCreateUserException e)
                {
                }
            }
            // If we got this far, something failed, redisplay form
            return View(user);

        }

        public bool CheckUsername(string data)
        {
            Debug.WriteLine(data);
            var username = (from user in _db.Users
                            where user.Username.Equals(data, StringComparison.InvariantCultureIgnoreCase)
                            select user).FirstOrDefault();
            if (username != null) return false;
            else return true;
        }
        public bool CheckEmail(string data)
        {
            Debug.WriteLine(data);
            var email = (from user in _db.Users
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