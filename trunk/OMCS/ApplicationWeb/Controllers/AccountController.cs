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
using OMCS.BLL;
using System.Data;
using System.Data.Entity.Validation;
using System.Threading;

namespace OMCS.Web.Controllers
{
    public class AccountController : BaseController
    {
        private AccountBusiness business = new AccountBusiness();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Where(u => u.Email == model.Email &&
                    u.Password == model.Password && u.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.Email = user.Email;
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

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

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

                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            }

            return View(model);
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

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
                    ModelState.AddModelError("", "Mã captcha không được để trống.");
                    return View(user);
                }

                var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

                if (recaptchaResult != RecaptchaVerificationResult.Success)
                {
                    ModelState.AddModelError("", "Mã Captcha không trùng khớp.");
                    return View(user);
                }

                // Attempt to register the user
                try
                {
                    Role role = _db.Roles.FirstOrDefault(r => r.RoleName == "User");
                    user.Roles = new List<Role>();
                    user.Roles.Add(role);
                    user.CreatedDate = DateTime.UtcNow;
                    user.ProfilePicture = "photo.jpg";
                    user.IsActive = false;
                    _db.Users.Add(user);
                    _db.SaveChanges();

                    string actCode = business.GeneratePassword();
                    Thread emailBackground = new Thread(delegate()
                    {
                        string subject = "Kích hoạt tài khoản";
                        string body = @"<html>
                                    <body>
                                        <h2>Chào mừng bạn đến với OMCS - Hệ thống tư vấn y khoa trực tuyến</h2>
                                        <p>Mã kích hoạt của bạn là: <b>" + actCode + "</b></p>" +
                                            @"<p>Vui lòng nhấn vào đường dẫn bên dưới để kích hoạt<br/>
                                            <a href='http://localhost:52443/Account/Activate/" + user.UserId + "?code=" + actCode + "'>" +
                                                   @"Kích hoạt tài khoản
                                            </a>
                                        </p>
                                    </body>
                                  </html>";

                        business.SendMail(user.Email, subject, body);
                    });
                    emailBackground.IsBackground = true;
                    emailBackground.Start();
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                }
            }
            // If we got this far, something failed, redisplay form

            return View(user);
        }

        //
        // GET: /Account/Activate

        public ActionResult Activate(int id, string code)
        {
            ViewBag.Code = code;
            ViewBag.Id = id;
            return View();
        }

        //
        // POST: /Account/Activate

        [HttpPost]
        [ActionName("Activate")]
        public ActionResult ActivatePost(int userId, string actCode, string code)
        {
            User user = _db.Users.Find(userId);
            if (code == actCode)
            {
                user.IsActive = true;
                _db.SaveChanges();
            }
            return RedirectToAction("Welcome", "Account");
        }

        //
        // GET: /Account/Welcome

        public ActionResult Welcome()
        {
            return View();
        }

        //
        // GET: /Account/ForgotPassword

        public ActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }

        //
        // POST: /Account/ForgotPassword

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User tUser = _db.Users.FirstOrDefault(u => u.Email == email);
                    tUser.Password = business.GeneratePassword();                             
                    tUser.Password = tUser.Password;
                    _db.Entry(tUser).State = EntityState.Modified;
                    _db.SaveChanges();          

                    Thread emailBackground = new Thread(delegate()
                    {
                        var subject = "Làm mới mật khẩu";
                        var body = "<html>" +
                                          "<body>" +
                                              "<h2>Hệ thống nhận được yêu cầu làm mới mật khẩu</h2>" +
                                              "<p>Mật khẩu mới: " + tUser.Password + "</p>" +
                                          "</body>" +
                                      "</html>";

                        business.SendMail(tUser.Email, subject, body);
                    });
                    emailBackground.IsBackground = true;
                    emailBackground.Start();                  
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
                    throw;
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]

        //
        // GET: /Account/LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        public JsonResult CheckExistEmail(string email)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return new JsonResult { Data = true };
            }
            return new JsonResult { Data = false };
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
    }
}