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
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Globalization;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminInformationController : BaseController
    {
        //
        // GET: /AdminInformation/
        public ActionResult Index()
        {
            User admin = _db.Users.Where(d => d.UserId == User.UserId).SingleOrDefault();
            return View(admin);
        }

        public JObject Save(string name, string value, int pk)
        {
            var user = _db.Users.Where(d => d.UserId == User.UserId).SingleOrDefault();
            Type type = typeof(User);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if ("birthday".Equals(name))
            {
                DateTime datetime = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                pi.SetValue(user, datetime);
            }
            else
            {
                pi.SetValue(user, Convert.ChangeType(value, pi.PropertyType), null);
            }
            _db.SaveChanges();
            JObject result = new JObject();
            result.Add("status", "success");
            return result;
        }

        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                try
                {
                    HttpPostedFileBase file = Request.Files[i];
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;
                    file.SaveAs(Server.MapPath("~/Content/Image/ProfilePicture/") + fileName);                    
                    string firstname = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().FirstName;
                    string lastname = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().LastName;
                    string password = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Password;
                    DateTime createDate = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().CreatedDate;
                    string gender = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Gender;
                    DateTime? birthDate = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Birthday;
                    string phone = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Phone;
                    string primary = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().PrimaryAddress;
                    string secondary = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().SecondaryAddress;
                    string email = _db.Users.Where(d => d.UserId == User.UserId).AsNoTracking().SingleOrDefault().Email;
                    User admin = new User();
                    admin.UserId = User.UserId;
                    admin.FirstName = firstname;
                    admin.LastName = lastname;
                    admin.Password = password;
                    admin.IsActive = true;
                    admin.Phone = phone;
                    admin.PrimaryAddress = primary;
                    admin.SecondaryAddress = secondary;
                    admin.CreatedDate = createDate;
                    admin.Birthday = birthDate;
                    admin.ProfilePicture = fileName;
                    admin.Email = email;
                    admin.Gender = gender;
                    _db.Entry(admin).State = EntityState.Modified;
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
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }

    }
}
