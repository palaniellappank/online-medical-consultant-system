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
     [CustomAuthorize(Roles= "User")]
    public class UserMedicalProfileController : BaseController
    {
        public ActionResult Index()
        {
            var medicalProfile = _db.MedicalProfiles.Where(a => a.PatientId == User.UserId).ToList();
            ViewBag.medic = medicalProfile;
            return View();
        }
    }
}