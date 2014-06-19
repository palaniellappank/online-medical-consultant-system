using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using PagedList;

namespace MvcApplication1.Controllers
{
    public class FilmTypeController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /FilmType/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<FilmType> filmTypes = db.FilmTypes.ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DescriptionSortParam = sortOrder == "Description" ? "Description_desc" : "Description";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                filmTypes = filmTypes.Where(f => f.Name.ToUpper().Contains(searchString.ToUpper())
                                            || f.Description.ToUpper().Contains(searchString.ToUpper()));
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "Name_desc":
                    filmTypes = filmTypes.OrderByDescending(f => f.Name);
                    break;
                case "Description_desc":
                    filmTypes = filmTypes.OrderByDescending(f => f.Description);
                    break;
                case "Description":
                    filmTypes = filmTypes.OrderBy(f => f.Description);
                    break;
                default:
                    filmTypes = filmTypes.OrderBy(f => f.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(filmTypes.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /FilmType/Create

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        //
        // POST: /FilmType/Create

        [HttpPost]
        public ActionResult Create(FilmType filmtype)
        {
            if (ModelState.IsValid)
            {
                db.FilmTypes.Add(filmtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_Create", filmtype);
        }

        //
        // GET: /FilmType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FilmType filmtype = db.FilmTypes.Find(id);
            if (filmtype == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", filmtype);
        }

        //
        // POST: /FilmType/Edit/5

        [HttpPost]
        public ActionResult Edit(FilmType filmtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", filmtype);
        }

        //
        // GET: /FilmType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FilmType filmtype = db.FilmTypes.Find(id);
            if (filmtype == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", filmtype);
        }

        //
        // POST: /FilmType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmType filmtype = db.FilmTypes.Find(id);
            db.FilmTypes.Remove(filmtype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /FilmType/CheckExistName
        [HttpPost]
        public JsonResult CheckExistName(string name,int id = 0)
        {
            var filmType = db.FilmTypes.FirstOrDefault(f => f.Name == name);
            if (filmType != null && id != filmType.FilmTypeId)
            {
                return new JsonResult { Data = false };
            }
            return new JsonResult { Data = true };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}