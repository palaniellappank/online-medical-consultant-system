using Newtonsoft.Json.Linq;
using OMCS.BLL;
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
            var medicalProfiles = _db.MedicalProfiles.Where(a => a.PatientId == User.UserId).ToList();
            ViewBag.medicalProfiles = medicalProfiles;
            return View(medicalProfiles);
        }

        public ActionResult Details(int medicalProfileId)
        {
            var medicalProfile = _db.MedicalProfiles.
                Where(x => x.MedicalProfileId == medicalProfileId).FirstOrDefault();
            ViewBag.medicalProfileName = medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateName;
            ViewBag.medicalProfileId = medicalProfile.MedicalProfileId;
            ViewBag.detailsInJson = business.ViewMedicalProfile(User.UserId, medicalProfile.MedicalProfileTemplate.MedicalProfileTemplateId);
            return View();
        }        
    }
}