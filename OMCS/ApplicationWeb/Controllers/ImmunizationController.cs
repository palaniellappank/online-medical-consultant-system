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
    public class ImmunizationController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /Immunization/

        public ActionResult Index()
        {
            var immunizations = db.Immunizations.Include(i => i.MedicalProfile);
            return View(immunizations.ToList());
        }

        //
        // GET: /Immunization/Details/5

        public ActionResult Details(int id = 0)
        {
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        //
        // GET: /Immunization/Create

        public ActionResult Create()
        {
            ViewBag.MedicalProfileId = new SelectList(db.MedicalProfiles, "MedicalProfileId", "HeartRate");
            return View();
        }

        //
        // POST: /Immunization/Create

        [HttpPost]
        public ActionResult Create(Immunization immunization)
        {
            if (ModelState.IsValid)
            {
                db.Immunizations.Add(immunization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicalProfileId = new SelectList(db.MedicalProfiles, "MedicalProfileId", "HeartRate", immunization.MedicalProfileId);
            return View(immunization);
        }

        //
        // GET: /Immunization/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicalProfileId = new SelectList(db.MedicalProfiles, "MedicalProfileId", "HeartRate", immunization.MedicalProfileId);
            return View(immunization);
        }

        //
        // POST: /Immunization/Edit/5

        [HttpPost]
        public ActionResult Edit(Immunization immunization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(immunization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicalProfileId = new SelectList(db.MedicalProfiles, "MedicalProfileId", "HeartRate", immunization.MedicalProfileId);
            return View(immunization);
        }

        //
        // GET: /Immunization/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return HttpNotFound();
            }
            return View(immunization);
        }

        //
        // POST: /Immunization/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Immunization immunization = db.Immunizations.Find(id);
            db.Immunizations.Remove(immunization);
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