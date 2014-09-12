using OMCS.BLL;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using OMCS.Web.DTO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Data;

namespace OMCS.Web.Controllers
{
    public class TreatmentHistoryPatientController : BaseController
    {
        private AdminUserBusiness business = new AdminUserBusiness();
        private MedicalProfileBusiness medicalProfileBusiness = new MedicalProfileBusiness();

        public ActionResult List(int medicalProfileId)
        {
            var treatments = _db.TreatmentHistories.Where(
                x => x.MedicalProfileId == medicalProfileId)
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            return PartialView("List", treatments);
        }

        public ActionResult Create(int medicalProfileId)
        {
            var doctor = _db.Doctors.ToList();
            ViewBag.Doctor = doctor;      
            var treatmentHistory = new TreatmentHistory
            {
                MedicalProfileId = medicalProfileId,
                OnSetDate = DateTime.Now,
                DateCreated = DateTime.Now
            };
            return PartialView("Create", treatmentHistory);
        }

        [HttpPost]
        public JObject Create(TreatmentHistory treatmentHistory)
        {
            _db.TreatmentHistories.Add(treatmentHistory);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }
    }
}