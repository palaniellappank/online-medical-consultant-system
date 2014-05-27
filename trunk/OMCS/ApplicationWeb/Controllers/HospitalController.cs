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
    public class HospitalController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /Hospital/

        public ActionResult Index()
        {
            return View(db.Hospitals.ToList());
        }

        //
        // GET: /Hospital/Details/5

        public ActionResult Details(int id = 0)
        {
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        //
        // GET: /Hospital/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hospital/Create

        [HttpPost]
        public ActionResult Create(Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital);
        }

        //
        // GET: /Hospital/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        //
        // POST: /Hospital/Edit/5

        [HttpPost]
        public ActionResult Edit(Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital);
        }

        //
        // GET: /Hospital/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        //
        // POST: /Hospital/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
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