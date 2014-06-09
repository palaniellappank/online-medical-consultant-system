using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;

namespace MvcApplication1.Controllers
{
    public class AdminSpecialtyFieldController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /AdminSpecialtyField/

        public ActionResult Index()
        {
            var specialtyfields = db.SpecialtyFields.Include(s => s.Parent).OrderBy(s => s.ParentId).ToList();
            var specialtyResult = new List<SpecialtyField>();
            foreach (var specialtyfield in specialtyfields)
            {
                if (specialtyfield.Parent == null)
                {
                    specialtyResult.Add(specialtyfield);
                    foreach (var child in specialtyfields)
                    {
                        if (child.Parent == specialtyfield)
                        {
                            specialtyResult.Add(child);
                        }
                    }
                }
            }
            return View(specialtyResult);
        }

        //
        // GET: /AdminSpecialtyField/Details/5

        public ActionResult Details(int id = 0)
        {
            SpecialtyField specialtyfield = db.SpecialtyFields.Find(id);
            if (specialtyfield == null)
            {
                return HttpNotFound();
            }
            return View(specialtyfield);
        }

        //
        // GET: /AdminSpecialtyField/Create

        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.SpecialtyFields, "SpecialtyFieldId", "Name");
            return View();
        }

        //
        // POST: /AdminSpecialtyField/Create

        [HttpPost]
        public ActionResult Create(SpecialtyField specialtyfield)
        {
            if (ModelState.IsValid)
            {
                db.SpecialtyFields.Add(specialtyfield);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.SpecialtyFields, "SpecialtyFieldId", "Name", specialtyfield.ParentId);
            return View(specialtyfield);
        }

        //
        // GET: /AdminSpecialtyField/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SpecialtyField specialtyfield = db.SpecialtyFields.Find(id);
            if (specialtyfield == null)
            {
                return HttpNotFound();
            }
            var generalSpecialty = db.SpecialtyFields.Where(
                    sf => sf.Parent == null
                ).ToList();
            ViewBag.ParentId = new SelectList(generalSpecialty, "SpecialtyFieldId", "Name", specialtyfield.ParentId);
            return PartialView("_Edit", specialtyfield);
        }

        //
        // POST: /AdminSpecialtyField/Edit/5

        [HttpPost]
        public ActionResult Edit(SpecialtyField specialtyfield)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialtyfield).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.SpecialtyFields, "SpecialtyFieldId", "Name", specialtyfield.ParentId);
            return View(specialtyfield);
        }

        //
        // GET: /AdminSpecialtyField/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SpecialtyField specialtyfield = db.SpecialtyFields.Find(id);
            if (specialtyfield == null)
            {
                return HttpNotFound();
            }
            return View(specialtyfield);
        }

        //
        // POST: /AdminSpecialtyField/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialtyField specialtyfield = db.SpecialtyFields.Find(id);
            db.SpecialtyFields.Remove(specialtyfield);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}