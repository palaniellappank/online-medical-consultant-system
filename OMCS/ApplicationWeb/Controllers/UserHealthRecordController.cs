using Newtonsoft.Json.Linq;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web.Controllers
{
     [CustomAuthorize(Roles= "User")]
    public class UserHealthRecordController : BaseController
    {
        public ActionResult Index()
        {
            Debug.WriteLine(User.UserId);
            var personalHealthRecord = _db.PersonalHealthRecords.Where(pa => pa.PatientId == User.UserId).SingleOrDefault();
            return View(personalHealthRecord);
        }

        public JObject Save(string name, string value, int pk)
        {
            var personalHealthRecord = _db.PersonalHealthRecords.Where(pa => pa.PatientId == User.UserId).SingleOrDefault();
            Type type = typeof(PersonalHealthRecord);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            pi.SetValue(personalHealthRecord, Convert.ChangeType(value, pi.PropertyType), null);
            _db.SaveChanges();
            JObject result = new JObject();
            result.Add("status", "success");
            return result;
        }
    }
}