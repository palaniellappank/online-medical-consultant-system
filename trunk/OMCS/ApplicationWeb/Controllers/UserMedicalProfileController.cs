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
            var medicalProfiles = _db.MedicalProfiles.Find(medicalProfileId);
            ViewBag.medicalProfiles = medicalProfiles;
            ViewBag.detailsInJson = business.DetailsMedicalProfileUser(medicalProfileId, User.UserId);                     
            return View();
        }        
    }
}