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
    public class DiseaseHistoryController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /DiseaseHistory/

        public ActionResult Index()
        {
            var diseasehistories = db.DiseaseHistories.Include(d => d.Patient).Include(d => d.Doctor).Include(d => d.DiseaseType);
            return View(diseasehistories.ToList());
        }

        //
        // GET: /DiseaseHistory/Details/5

        public ActionResult Details(int id = 0)
        {
            DiseaseHistory diseasehistory = db.DiseaseHistories.Find(id);
            if (diseasehistory == null)
            {
                return HttpNotFound();
            }
            return View(diseasehistory);
        }

        //
        // GET: /DiseaseHistory/Create

        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username");
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username");
            ViewBag.DiseaseTypeId = new SelectList(db.DiseaseTypes, "DiseaseTypeId", "Name");
            return View();
        }

        //
        // POST: /DiseaseHistory/Create

        [HttpPost]
        public ActionResult Create(DiseaseHistory diseasehistory)
        {
            if (ModelState.IsValid)
            {
                db.DiseaseHistories.Add(diseasehistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username", diseasehistory.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username", diseasehistory.DoctorId);
            ViewBag.DiseaseTypeId = new SelectList(db.DiseaseTypes, "DiseaseTypeId", "Name", diseasehistory.DiseaseTypeId);
            return View(diseasehistory);
        }

        //
        // GET: /DiseaseHistory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DiseaseHistory diseasehistory = db.DiseaseHistories.Find(id);
            if (diseasehistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username", diseasehistory.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username", diseasehistory.DoctorId);
            ViewBag.DiseaseTypeId = new SelectList(db.DiseaseTypes, "DiseaseTypeId", "Name", diseasehistory.DiseaseTypeId);
            return View(diseasehistory);
        }

        //
        // POST: /DiseaseHistory/Edit/5

        [HttpPost]
        public ActionResult Edit(DiseaseHistory diseasehistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diseasehistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username", diseasehistory.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username", diseasehistory.DoctorId);
            ViewBag.DiseaseTypeId = new SelectList(db.DiseaseTypes, "DiseaseTypeId", "Name", diseasehistory.DiseaseTypeId);
            return View(diseasehistory);
        }

        //
        // GET: /DiseaseHistory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DiseaseHistory diseasehistory = db.DiseaseHistories.Find(id);
            if (diseasehistory == null)
            {
                return HttpNotFound();
            }
            return View(diseasehistory);
        }

        //
        // POST: /DiseaseHistory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DiseaseHistory diseasehistory = db.DiseaseHistories.Find(id);
            db.DiseaseHistories.Remove(diseasehistory);
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