using Newtonsoft.Json.Linq;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
     [CustomAuthorize(Roles= "User")]
    public class UserInfoController : BaseController
    {
        public ActionResult Index()
        {
            Debug.WriteLine(User.UserId);
            var patient = _db.Patients.Where(pa => pa.UserId == User.UserId).SingleOrDefault();
            return View(patient);
        }

        public JObject Save(string name, string value, int pk)
        {
            var patient = _db.Patients.Where(pa => pa.UserId == User.UserId).SingleOrDefault();
            Type type = typeof(Patient);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if ("birthday".Equals(name))
            {
                DateTime datetime = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                pi.SetValue(patient, datetime);
            } else
            {
                pi.SetValue(patient, Convert.ChangeType(value, pi.PropertyType), null);
            }
            _db.SaveChanges();
            JObject result = new JObject();
            result.Add("status", "error");
            result.Add("msg", "huhu");
            return result;
        }
    }
}