using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
    // [CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
   // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
     [CustomAuthorize(Roles= "User")]
    // [CustomAuthorize(Users = "1,2")]
    public class UserController : BaseController
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
    }
}