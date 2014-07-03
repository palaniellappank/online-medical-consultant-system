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

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Doctor")]
    public class DoctorUserController : BaseController
    {
        private AdminUserBusiness business = new AdminUserBusiness();
        private MedicalProfileBusiness medicalProfileBusiness = new MedicalProfileBusiness();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<User> users = _db.Roles.Where(r => r.RoleName == "User").SelectMany(r => r.Users);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserSortParam = String.IsNullOrEmpty(sortOrder) ? "User_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.IsActiveParam = sortOrder == "Active" ? "Active_desc" : "Active";
            ViewBag.NameSortParam = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.PhoneSortParam = sortOrder == "Phone" ? "Phone_desc" : "Phone";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            business.SearchByString(searchString, ref users);//Search UserName/Fullname by string
            business.CheckSortOrder(sortOrder, ref users);// Check sort order to sort with the corresponding column

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult View(int id)
        {
            var patient = _db.Patients.Find(id);
            var personalHealthRecord = _db.PersonalHealthRecords.Find(id);
            var medicalProfiles = _db.MedicalProfiles.Where(mp => mp.PatientId == id).ToList();
            var medicalProfileTemplates = _db.MedicalProfileTemplates.ToList();
            SelectList medicalProfileTemplateList = new SelectList(medicalProfileTemplates, 
                "MedicalProfileTemplateId", "MedicalProfileTemplateName", 
                medicalProfileTemplates.First());
            PatientInformation PatientInformation = new PatientInformation
            {
                Patient = patient,
                PersonalHealthRecord = personalHealthRecord,
                MedicalProfiles = medicalProfiles
            };
            ViewBag.medicalProfileTemplateList = medicalProfileTemplateList;
            return PartialView("_View", PatientInformation);
        }

        public ActionResult UpdateMedicalProfile(int id, int medicalProfileTemplateId)
        {
            var medicalProfile = _db.MedicalProfiles.Where(
                mp => ((mp.PatientId == id) &&
                    (mp.MedicalProfileTemplateId == medicalProfileTemplateId))
            ).FirstOrDefault();
            var str = medicalProfileBusiness.UpdateMedicalProfile(id, medicalProfileTemplateId);
            ViewBag.formInJson = str;
            ViewBag.patientId = id;
            ViewBag.medicalProfileTemplateId = medicalProfileTemplateId;
            ViewBag.medicalProfileName = _db.MedicalProfileTemplates.Find(medicalProfileTemplateId).MedicalProfileTemplateName;
            if (medicalProfile != null)
                ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            else ViewBag.medicalProfileId = 0;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateMedicalProfile(FormCollection formCollection)
        {
            medicalProfileBusiness.UpdateMedicalProfileForPatient(formCollection);
            return View();
        }
    }
}