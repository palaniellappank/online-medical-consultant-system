using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using System.IO;
using PagedList;
using OMCS.BLL;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading;
using Security.DAL.Security;
using Newtonsoft.Json.Linq;

namespace OMCS.Web.Controllers
{
    public class AdminCommentController : BaseController
    {
        //
        // GET: /AdminComment/
        AdminCommentBusiness commentBusiness = new AdminCommentBusiness();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Comment> comment = _db.Comments.Where(r => r.CommentId != 0).ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;           
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.ContentSortParam = sortOrder == "Content" ? "Content_desc" : "Content";
            ViewBag.PatientNameSortParam = sortOrder == "PatientName" ? "PatientName_desc" : "PatientName";
            ViewBag.DoctorNameSortParam = sortOrder == "DoctorName" ? "DoctorName_desc" : "DoctorName";          

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            commentBusiness.SearchByString(searchString, ref comment);
            commentBusiness.CheckSortOrder(sortOrder, ref comment);
            return View(comment.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Delete(int id = 0)
        {
            Comment comment = _db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", comment);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = _db.Comments.Find(id);
            _db.Comments.Remove(comment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
