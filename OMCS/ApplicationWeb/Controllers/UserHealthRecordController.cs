using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
     [CustomAuthorize(Roles= "User")]
    public class UserHealthRecordController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}