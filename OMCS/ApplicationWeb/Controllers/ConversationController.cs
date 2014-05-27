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
    public class ConversationController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /Conversation/

        public ActionResult Index()
        {
            var conversations = db.Conversations.Include(c => c.Patient).Include(c => c.Doctor);
            return View(conversations.ToList());
        }

        //
        // GET: /Conversation/Details/5

        public ActionResult Details(int id = 0)
        {
            Conversation conversation = db.Conversations.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            return View(conversation);
        }

        //
        // GET: /Conversation/Create

        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username");
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        //
        // POST: /Conversation/Create

        [HttpPost]
        public ActionResult Create(Conversation conversation)
        {
            if (ModelState.IsValid)
            {
                db.Conversations.Add(conversation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username", conversation.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username", conversation.DoctorId);
            return View(conversation);
        }

        //
        // GET: /Conversation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Conversation conversation = db.Conversations.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username", conversation.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username", conversation.DoctorId);
            return View(conversation);
        }

        //
        // POST: /Conversation/Edit/5

        [HttpPost]
        public ActionResult Edit(Conversation conversation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conversation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Users, "UserId", "Username", conversation.PatientId);
            ViewBag.DoctorId = new SelectList(db.Users, "UserId", "Username", conversation.DoctorId);
            return View(conversation);
        }

        //
        // GET: /Conversation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Conversation conversation = db.Conversations.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            return View(conversation);
        }

        //
        // POST: /Conversation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Conversation conversation = db.Conversations.Find(id);
            db.Conversations.Remove(conversation);
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