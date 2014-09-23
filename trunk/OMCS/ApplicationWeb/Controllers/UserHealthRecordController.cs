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
    [CustomAuthorize(Roles = "User, Doctor")]
    public class UserHealthRecordController : BaseController
    {
        private OMCSDBContext db = new OMCSDBContext();
        public ActionResult Index()
        {
            var patient = _db.Patients.Where(x => x.UserId == User.UserId).FirstOrDefault();
            return View(patient.PersonalHealthRecord);
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

        public ActionResult ShowAllergyList(int id)
        {
            var allergyList = _db.Allergies.Where(a => a.MedicalProfile.Patient.UserId == id)
                .OrderBy(x=>x.MedicalProfileId).ToList();
            return PartialView("_AllergyList", allergyList);
        }

        public ActionResult ShowImmunizationList(int id)
        {
            var immunizationList = _db.Immunizations.Where(i => i.MedicalProfile.PatientId == id)
                .OrderBy(x=>x.MedicalProfileId).ToList();
            return PartialView("_ImmunizationList", immunizationList);
        }
    }
}