using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using Security.DAL.Security;

namespace OMCS.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminSpecialtyFieldController : BaseController
    {
        private OMCSDBContext db = new OMCSDBContext();

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

        public ActionResult Create(bool isChild = false)
        {
            var generalSpecialty = db.SpecialtyFields.Where(
                    sf => sf.Parent == null
                ).ToList();
            generalSpecialty.Add(null);
            ViewBag.ParentId = new SelectList(generalSpecialty, "SpecialtyFieldId", "Name");
            ViewBag.IsChild = isChild;
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(SpecialtyField specialtyfield)
        {
            if (ModelState.IsValid)
            {
                db.SpecialtyFields.Add(specialtyfield);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

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
            generalSpecialty.Add(null);
            ViewBag.ParentId = new SelectList(generalSpecialty, "SpecialtyFieldId", "Name", specialtyfield.ParentId);
            return PartialView("_Edit", specialtyfield);
        }

        [HttpPost]
        public ActionResult Edit(SpecialtyField specialtyfield)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialtyfield).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            SpecialtyField specialtyfield = db.SpecialtyFields.Find(id);
            if (specialtyfield == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", specialtyfield);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialtyField specialtyfield = db.SpecialtyFields.Find(id);
            var childNode = db.SpecialtyFields.Where(s => s.ParentId == id).ToList();
            foreach (var child in childNode)
            {
                db.SpecialtyFields.Remove(child);
            }
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