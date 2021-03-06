﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using OMCS.BLL;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;

namespace OMCS.Web.Controllers
{
    public class MedicalProfileTemplateController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        MedicalProfileTemplateBusiness business = new MedicalProfileTemplateBusiness();

        public ActionResult Index()
        {
            var medicalrecordtemplates = db.MedicalProfileTemplates.Include(m => m.MedicalProfileType);
            return View(medicalrecordtemplates.ToList());
        }

        public ActionResult Editor(int id)
        {
            if (id == 0)
            {
                //Create Mode
                ViewBag.formInJson = "[]";
            }
            else
            {
                //Edit Mode
                string json = business.ShowTemplate(id);
                var template = db.MedicalProfileTemplates.Find(id);
                ViewBag.formInJson = json;
                ViewBag.template = template;
            }
            ViewBag.medicalProfileTemplateId = id;
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public JArray DetailInJson(int id)
        {
            var listCustomSnippets = db.CustomSnippets.Where(s => s.MedicalProfileTemplateId == id).ToList();
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
            return result;
        }

        public ActionResult Delete(int id = 0)
        {
            MedicalProfileTemplate medicalrecordtemplate = db.MedicalProfileTemplates.Find(id);
            if (medicalrecordtemplate == null)
            {
                return HttpNotFound();
            }
            return View(medicalrecordtemplate);
        }

        //
        // POST: /MedicalProfileTemplate/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalProfileTemplate medicalrecordtemplate = db.MedicalProfileTemplates.Find(id);
            db.MedicalProfileTemplates.Remove(medicalrecordtemplate);
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