using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.IO;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminInformationHospitalController : BaseController
    {
        //
        // GET: /AdminInformationHospital/
        private OMCSDBContext _db = new OMCSDBContext();

        public ActionResult Index()
        {
            var doctorCount = _db.Doctors.Count();
            ViewBag.doctorCount = doctorCount;
            IEnumerable<Doctor> doctor = _db.Doctors.Where(r => r.UserId != 0).Take(5);
            ViewBag.doctor = doctor;
            var specialtyfields = _db.SpecialtyFields.Where(s => s.SpecialtyFieldId != 0).ToList();
            ViewBag.specialtyfields = specialtyfields;
            var speCount = _db.SpecialtyFields.Count();
            ViewBag.speCount = speCount;
            int hospitalId = _db.HospitalInformations.Where(h => h.HospitalInformationId != 0).AsNoTracking().SingleOrDefault().HospitalInformationId;
            var hospitalInformation = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).SingleOrDefault();
            IEnumerable<MedicalProfile> medical = _db.MedicalProfiles.Where(m => m.MedicalProfileId != 0).ToList();
            ViewBag.medical = medical;
            var medicalCount = _db.MedicalProfiles.Count();
            ViewBag.medicalCount = medicalCount;
            return View(hospitalInformation);
        }

        public JObject Save(string name, string value, int pk)
        {
            int hospitalId = _db.HospitalInformations.Where(h => h.HospitalInformationId != 0).AsNoTracking().SingleOrDefault().HospitalInformationId;
            var hospitalInformation = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).SingleOrDefault();
            Type type = typeof(HospitalInformation);
            PropertyInfo pi = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            pi.SetValue(hospitalInformation, Convert.ChangeType(value, pi.PropertyType), null);
            _db.SaveChanges();
            JObject result = new JObject();
            result.Add("status", "success");
            return result;
        }

        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                file.SaveAs(Server.MapPath("~/Content/Image/Logo/") + fileName);
                int hospitalId = _db.HospitalInformations.Where(h => h.HospitalInformationId != 0).AsNoTracking().SingleOrDefault().HospitalInformationId;
                string name = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).AsNoTracking().FirstOrDefault().Name;
                string address = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).AsNoTracking().FirstOrDefault().Address;
                string email = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).AsNoTracking().FirstOrDefault().Email;
                string phone = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).AsNoTracking().FirstOrDefault().Phone;
                string fax = _db.HospitalInformations.Where(h => h.HospitalInformationId == hospitalId).AsNoTracking().FirstOrDefault().Fax;  
                HospitalInformation hospital = new HospitalInformation();
                hospital.HospitalInformationId = hospitalId;
                hospital.Logo = fileName;
                hospital.Name = name;
                hospital.Email = email;
                hospital.Address = address;
                hospital.Phone = phone;
                hospital.Fax = fax;
                _db.Entry(hospital).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }
    }
}
