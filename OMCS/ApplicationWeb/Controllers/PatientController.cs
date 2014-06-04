using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace MvcApplication1.Controllers
{
    public class PatientController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        //
        // GET: /Patient/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Patient/Details/5

        public ActionResult Details(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        public ActionResult UpdateMedicalProfile(int id, int medicalProfileTemplateId)
        {
            Debug.WriteLine(id + "  " + medicalProfileTemplateId);
            var medicalProfile = db.MedicalProfiles.Where(
                mp => ((mp.PatientId== id) &&
                    (mp.MedicalProfileTemplateId == medicalProfileTemplateId))
            ).FirstOrDefault();
            if (medicalProfile == null)
            {
                Debug.WriteLine("Go to null");
                db.MedicalProfiles.Add(new MedicalProfile
                {
                    PatientId = id,
                    MedicalProfileTemplateId = medicalProfileTemplateId
                });
                db.SaveChanges();
            }
            var listCustomSnippets = db.CustomSnippets.Where(
                s => s.MedicalProfileTemplateId == medicalProfileTemplateId
            ).ToList();
            dynamic result = new JArray();
            foreach (var customSnippet in listCustomSnippets)
            {
                dynamic snippet = new JObject();
                snippet.title = customSnippet.Title;
                snippet.fields = new JObject() as dynamic;
                var listCustomSnippetFields = from snippetField in db.CustomSnippetFields
                                              where snippetField.CustomSnippetId == customSnippet.CustomSnippetId
                                              select snippetField;
                foreach (var customSnippetField in listCustomSnippetFields)
                {
                    dynamic metadata = new JObject();
                    dynamic value;
                    if (customSnippetField.Value.Contains("[") && customSnippetField.Value.Contains("]"))
                    {
                        value = JArray.Parse(customSnippetField.Value);
                    }
                    else
                    {
                        value = customSnippetField.Value;
                    }
                    metadata.label = customSnippetField.Label;
                    metadata.type = customSnippetField.Type;
                    metadata.value = value;
                    metadata.name = customSnippetField.Name;
                    snippet.fields.Add(customSnippetField.FieldName, metadata);
                }
                result.Add(snippet);
            }
            Debug.WriteLine("Haha ne");
            string str = ((object)result).ToString();
            Debug.WriteLine("9" + str);
            ViewBag.formInJson = str;
            ViewBag.patientId = id;
            ViewBag.medicalProfileTemplateId = medicalProfileTemplateId;
            return View();
        }

        //
        // GET: /Patient/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Patient/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        //
        // GET: /Patient/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Patient/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        //
        // GET: /Patient/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Patient/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Users.Remove(patient);
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