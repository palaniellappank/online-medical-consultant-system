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

        public ActionResult UpdateMedicalProfile(int id, int medicalProfileTemplateId)
        {
            var str = medicalBusiness.UpdateMedicalProfile(id, medicalProfileTemplateId);
            ViewBag.formInJson = str;
            ViewBag.patientId = id;
            ViewBag.medicalProfileTemplateId = medicalProfileTemplateId;
            ViewBag.medicalProfileName = _db.MedicalProfileTemplates.Find(medicalProfileTemplateId).MedicalProfileTemplateName;

            var medicalProfile = _db.MedicalProfiles.Where(
                mp => ((mp.PatientId == id) &&
                    (mp.MedicalProfileTemplateId == medicalProfileTemplateId))
            ).FirstOrDefault();
            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            return View();
        }

        public ActionResult ViewMedicalProfile(int id, int medicalProfileTemplateId)
        {
            var medicalProfile = _db.MedicalProfiles.
                Where(x => x.MedicalProfileTemplateId == medicalProfileTemplateId
                && x.PatientId == id).FirstOrDefault();
            ViewBag.medicalProfileName = medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateName;
            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            ViewBag.detailsInJson = medicalBusiness.ViewMedicalProfile(id, medicalProfileTemplateId);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateMedicalProfile(FormCollection formCollection)
        {
            medicalBusiness.UpdateMedicalProfileForPatient(formCollection);
            return View();
        }
    }
}