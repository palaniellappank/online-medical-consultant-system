using Newtonsoft.Json.Linq;
using OMCS.BLL;
using OMCS.DAL.Model;
using OMCS.Web.DTO;
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
    [CustomAuthorize(Roles = "User")]
    public class UserMedicalProfileController : BaseController
    {
        MedicalProfileBusiness business = new MedicalProfileBusiness();
        CustomSnippetBusiness snippetBusiness;

        public UserMedicalProfileController()
        {
            snippetBusiness = new CustomSnippetBusiness(_db);
        }

        public ActionResult Index()
        {
            var patient = _db.Patients.Find(User.UserId);
            var medicalProfiles = _db.MedicalProfiles.Where(mp => mp.PatientId == User.UserId).ToList();
            var medicalProfileTemplates = _db.MedicalProfileTemplates.ToList();
            SelectList medicalProfileTemplateList = new SelectList(medicalProfileTemplates,
                "MedicalProfileTemplateId", "MedicalProfileTemplateName",
                medicalProfileTemplates.First());
            var doctorName = _db.Doctors.ToList();
            SelectList doctorNameList = new SelectList(doctorName,
                "UserId", "FullName",
                doctorName.First());
            ViewBag.doctorNameList = doctorNameList;
            PatientInformation PatientInformation = new PatientInformation
            {
                Patient = patient,
                MedicalProfiles = medicalProfiles
            };
            ViewBag.medicalProfileTemplateList = medicalProfileTemplateList;
            return PartialView("Index", PatientInformation);
        }

        public ActionResult Details(int medicalProfileId)
        {
            var medicalProfile = _db.MedicalProfiles.
                Where(x => x.MedicalProfileId == medicalProfileId).FirstOrDefault();
            ViewBag.medicalProfileName = medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateName;
            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            ViewBag.detailsInJson = business.ViewMedicalProfile(User.UserId, medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateId);
            ViewBag.doctor = medicalProfile.Doctor;
            ViewBag.createdDate = medicalProfile.CreatedDate;
            ViewBag.hospital = _db.HospitalInformations.First().Name;
            return View();
        }

        public ActionResult UpdateMedicalProfile(int id = 0, int medicalProfileTemplateId = 0, int doctorId = 0, int medicalProfileId = 0)
        {
            MedicalProfile medicalProfile;          
            //Get Medical Profile by medicalProfileId
            if (medicalProfileId != 0)
            {
                medicalProfile = _db.MedicalProfiles.Find(medicalProfileId);
                ViewBag.formInJson = business.UpdateMedicalProfile(
                    medicalProfile.PatientId, medicalProfile.MedicalProfileTemplateId, doctorId);
            }
            else
            {
                //Get Medical Profile by patientId and medicalProfileTemplateId
                medicalProfile = _db.MedicalProfiles.
                    Where(x => x.MedicalProfileTemplateId == medicalProfileTemplateId
                    && x.PatientId == id).FirstOrDefault();
                ViewBag.formInJson = business.UpdateMedicalProfile(id, medicalProfileTemplateId, doctorId);
                if (medicalProfile == null)
                {
                    medicalProfile = _db.MedicalProfiles.
                    Where(x => x.MedicalProfileTemplateId == medicalProfileTemplateId
                    && x.PatientId == id).FirstOrDefault();
                }
            }
            ViewBag.patientId = medicalProfile.PatientId;
            ViewBag.medicalProfileTemplateId = medicalProfile.MedicalProfileTemplateId;
            ViewBag.medicalProfileName = _db.MedicalProfileTemplates.Find(medicalProfile.MedicalProfileTemplateId).MedicalProfileTemplateName;

            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            ViewBag.doctor = medicalProfile.Doctor;
            ViewBag.createdDate = medicalProfile.CreatedDate;
            ViewBag.hospital = _db.HospitalInformations.First().Name;
            return View();
        }

        [HttpPost]
        public JObject UpdateMedicalProfile(FormCollection formCollection)
        {
            business.UpdateMedicalProfileForPatient(formCollection);
            dynamic result = new JObject();
            result.result = "success";
            return result;
        }
    }
}