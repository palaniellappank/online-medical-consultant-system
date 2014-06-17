﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using System.IO;
using PagedList;
using Security.Controllers;
using OMCS.BLL;

namespace OMCS.Web.Controllers
{
    public class AdminTemplateController : BaseController
    {
        private MedicalProfileTemplateBusiness business = new MedicalProfileTemplateBusiness();

        public ActionResult Index()
        {
            var medicalProfileTemplates = _db.MedicalProfileTemplates.ToList();
            return View(medicalProfileTemplates);
        }

        public ActionResult Editor(int id)
        {
            string json = business.ShowTemplate(id);
            ViewBag.formInJson = json;
            ViewBag.medicalProfileTemplateId = id;
            if (id != 0)
            {
                MedicalProfileTemplate medicalProfileTemplate = _db.MedicalProfileTemplates.Find(id);
                return View(medicalProfileTemplate);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult CreateFromName(string name)
        {
            MedicalProfileTemplate template = new MedicalProfileTemplate
            {
                MedicalProfileTemplateName = name
            };
            _db.MedicalProfileTemplates.Add(template);
            _db.SaveChanges();
            return RedirectToAction("Editor", new { id = template.MedicalProfileTemplateId });
        }

        public ActionResult Edit(int id = 0)
        {
            MedicalProfileTemplate medicalProfileTemplate = _db.MedicalProfileTemplates.Find(id);
            if (medicalProfileTemplate == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", medicalProfileTemplate);
        }

        [HttpPost]
        public ActionResult Edit(MedicalProfileTemplate medicalProfileTemplate)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(medicalProfileTemplate).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            MedicalProfileTemplate medicalProfileTemplate = _db.MedicalProfileTemplates.Find(id);
            if (medicalProfileTemplate == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", medicalProfileTemplate);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalProfileTemplate medicalProfileTemplate = _db.MedicalProfileTemplates.Find(id);
            _db.MedicalProfileTemplates.Remove(medicalProfileTemplate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}