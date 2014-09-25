using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles= "Doctor")]
    public class DoctorConversationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPatient()
        {
            return PartialView("_SearchPatient");
        }
    }
}