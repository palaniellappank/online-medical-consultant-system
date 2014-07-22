using Newtonsoft.Json.Linq;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using OMCS.BLL;

namespace OMCS.Web.Controllers
{
     [CustomAuthorize(Roles= "User")]
    public class UserInfoController : BaseController
    {
        PatientBusiness userBusiness;

        public UserInfoController()
        {
            userBusiness = new PatientBusiness(_db);
        }

        public ActionResult Index()
        {
            var patient = _db.Patients.Where(pa => pa.UserId == User.UserId).SingleOrDefault();
            return View(patient);
        }

        public JObject Save(string name, string value, int pk)
        {
            var patient = _db.Patients.Where(pa => pa.UserId == User.UserId).SingleOrDefault();
            Type type = typeof(Patient);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if ("birthday".Equals(name) || "healthInsuranceIssued".Equals(name) || "healthInsuranceDateExpired".Equals(name))
            {
                DateTime datetime = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                pi.SetValue(patient, datetime);
            } else
            {
                pi.SetValue(patient, Convert.ChangeType(value, pi.PropertyType), null);
            }
            _db.SaveChanges();
            JObject result = new JObject();
            result.Add("status", "success");
            return result;
        }
    }
}