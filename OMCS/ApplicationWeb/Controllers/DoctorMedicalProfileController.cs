using OMCS.BLL;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Doctor")]
    public class DoctorMedicalProfileController : BaseController
    {       
        MedicalProfileBusiness medicalBusiness = new MedicalProfileBusiness();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<MedicalProfile> medicalProfiles = _db.MedicalProfiles.Where(r => r.MedicalProfileId != 0).ToList();                        
            ViewBag.CurrentFilter = searchString;                                       
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserSortParam = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.KeyParam = sortOrder == "MedicalProfileKey" ? "MedicalProfileKey_desc" : "MedicalProfileKey";
            ViewBag.NameSortParam = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.MedicalNameSortParam = sortOrder == "MedicalProfileName" ? "MedicalProfileName_desc" : "MedicalProfileName";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            medicalBusiness.SearchByStringMedical(searchString, ref medicalProfiles);
            medicalBusiness.CheckSortOrderMedical(sortOrder, ref medicalProfiles);
            return View(medicalProfiles.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Delete(int id = 0)
        {
            MedicalProfile medical = _db.MedicalProfiles.Find(id);
            if (medical == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", medical);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteOrderDetails = from details in _db.CustomSnippetValues where details.MedicalProfileId == id select details;

            foreach (var detail in deleteOrderDetails)
            {
                _db.CustomSnippetValues.Remove(detail);
            }

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            MedicalProfile medical = _db.MedicalProfiles.Find(id);
            _db.MedicalProfiles.Remove(medical);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return RedirectToAction("Index");
        }

        public ActionResult UpdateMedicalProfile(int id = 0, int medicalProfileTemplateId = 0, int medicalProfileId = 0)
        {
            MedicalProfile medicalProfile;
            //Get Medical Profile by medicalProfileId
            if (medicalProfileId != 0)
            {
                medicalProfile = _db.MedicalProfiles.Find(medicalProfileId);
                ViewBag.formInJson = medicalBusiness.UpdateMedicalProfile(
                    medicalProfile.PatientId, medicalProfile.MedicalProfileTemplateId, User.UserId);
            }
            else
            {
                //Get Medical Profile by patientId and medicalProfileTemplateId
                medicalProfile = _db.MedicalProfiles.
                    Where(x => x.MedicalProfileTemplateId == medicalProfileTemplateId
                    && x.PatientId == id).FirstOrDefault();
                ViewBag.formInJson = medicalBusiness.UpdateMedicalProfile(id, medicalProfileTemplateId, User.UserId);
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

        public ActionResult ViewMedicalProfile(int id = 0, int medicalProfileTemplateId = 0, int medicalProfileId = 0)
        {
            MedicalProfile medicalProfile;
            //Get Medical Profile by medicalProfileId
            if (medicalProfileId != 0)
            {
                medicalProfile = _db.MedicalProfiles.Find(medicalProfileId);
                ViewBag.detailsInJson = medicalBusiness.ViewMedicalProfile(
                    medicalProfile.PatientId, medicalProfile.MedicalProfileTemplateId);
            }
            else
            {
                //Get Medical Profile by patientId and medicalProfileTemplateId
                medicalProfile = _db.MedicalProfiles.
                    Where(x => x.MedicalProfileTemplateId == medicalProfileTemplateId
                    && x.PatientId == id).FirstOrDefault();
                ViewBag.detailsInJson = medicalBusiness.ViewMedicalProfile(id, medicalProfileTemplateId);
            }
            ViewBag.medicalProfileName = medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateName;
            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            ViewBag.doctor = medicalProfile.Doctor;
            ViewBag.createdDate = medicalProfile.CreatedDate;
            ViewBag.hospital = _db.HospitalInformations.First().Name;
            return View();
        }

        public ActionResult GetLastestMedicalProfile(string email)
        {
            var medicalProfile = _db.MedicalProfiles.
                Where(x => x.Patient.Email == email).OrderByDescending(x=>x.CreatedDate).
                Take(1).FirstOrDefault();
            ViewBag.medicalProfile = medicalProfile;
            return PartialView("_LatestMedicalProfile", medicalProfile);
        }

        [HttpPost]
        public JObject UpdateMedicalProfile(FormCollection formCollection)
        {
            medicalBusiness.UpdateMedicalProfileForPatient(formCollection);
            dynamic result = new JObject();
            result.result = "success";
            return result;
        }

        public JArray GetMedicalProfileList(string patientEmail)
        {
            var medicalProfiles = _db.MedicalProfiles.
                Where(x => x.Patient.Email.Equals(patientEmail)).
                OrderByDescending(x => x.CreatedDate).ToList();
            dynamic medicalProfileListJson = new JArray();
            dynamic medicalProfileJson = new JObject();
            medicalProfileJson.id = null;
            medicalProfileJson.text = "Khám bệnh tự do";
            medicalProfileListJson.Add(medicalProfileJson);
            foreach (var medicalProfile in medicalProfiles)
            {
                medicalProfileJson = new JObject();
                medicalProfileJson.id = medicalProfile.MedicalProfileId;
                medicalProfileJson.text = medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateName;
                medicalProfileListJson.Add(medicalProfileJson);
            }
            return medicalProfileListJson;
        }
    }
}