using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web.Controllers
{
     [CustomAuthorize(Roles= "User")]
    public class UserMedicalProfileController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}