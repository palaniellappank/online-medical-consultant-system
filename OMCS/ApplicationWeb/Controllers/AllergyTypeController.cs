using OMCS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcApplication1.Controllers
{
    public class AllergyTypeController : Controller
    {
        private OMCSDBContext _db = new OMCSDBContext();

        //
        // GET: /AllergyType/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<AllergyType> allergyTypes = _db.AllergyTypes.ToList();
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
                allergyTypes = allergyTypes.Where(f => f.Name.ToUpper().Contains(searchString.ToUpper())
                                            || f.Description.ToUpper().Contains(searchString.ToUpper()));
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "Name_desc":
                    allergyTypes = allergyTypes.OrderByDescending(f => f.Name);
                    break;
                case "Description_desc":
                    allergyTypes = allergyTypes.OrderByDescending(f => f.Description);
                    break;
                case "Description":
                    allergyTypes = allergyTypes.OrderBy(f => f.Description);
                    break;
                default:
                    allergyTypes = allergyTypes.OrderBy(f => f.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(allergyTypes.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(AllergyType allergyTypes)
        {
            if (ModelState.IsValid)
            {
                _db.AllergyTypes.Add(allergyTypes);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_Create", allergyTypes);
        }

        //
        // GET: /FilmType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AllergyType allergyType = _db.AllergyTypes.Find(id);
            if (allergyType == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", allergyType);
        }

        //
        // POST: /FilmType/Edit/5

        [HttpPost]
        public ActionResult Edit(AllergyType allergyTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(allergyTypes).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", allergyTypes);
        }

        //
        // GET: /FilmType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AllergyType allergyTypes = _db.AllergyTypes.Find(id);
            if (allergyTypes == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", allergyTypes);
        }

        //
        // POST: /FilmType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AllergyType allergyTypes = _db.AllergyTypes.Find(id);
            _db.AllergyTypes.Remove(allergyTypes);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /FilmType/CheckExistName
        [HttpPost]
        public JsonResult CheckExistName(string name, int id = 0)
        {
            var allergyTypes = _db.AllergyTypes.FirstOrDefault(f => f.Name == name);
            if (allergyTypes != null && id != allergyTypes.AllergyTypeId)
            {
                return new JsonResult { Data = false };
            }
            return new JsonResult { Data = true };
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
