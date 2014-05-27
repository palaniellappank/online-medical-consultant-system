using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
    [CustomAuthorize(Roles = "HospitalAdmin")]
    public class HospitalAdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}