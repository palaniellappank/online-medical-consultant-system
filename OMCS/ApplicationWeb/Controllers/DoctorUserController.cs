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

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Doctor")]
    public class DoctorUserController : BaseController
    {
        private AdminUserBusiness business = new AdminUserBusiness();

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
            PatientInformation PatientInformation = new PatientInformation
            {
                Patient = patient,
                PersonalHealthRecord = personalHealthRecord
            };
            return PartialView("_View", PatientInformation);
        }
    }
}