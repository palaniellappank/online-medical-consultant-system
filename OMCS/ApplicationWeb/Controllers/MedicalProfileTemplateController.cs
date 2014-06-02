using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MvcApplication1.Controllers
{
    public class MedicalProfileTemplateController : Controller
    {
        private OMCSDBContext db = new OMCSDBContext();

        public ActionResult Index()
        {
            var medicalrecordtemplates = db.MedicalProfileTemplates.Include(m => m.MedicalProfileType);
            return View(medicalrecordtemplates.ToList());
        }

        public ActionResult Editor(int id)
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
            string json = JsonConvert.SerializeObject(result, Formatting.None);
            ViewBag.formInJson = json;
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

        //
        // GET: /MedicalProfileTemplate/Create

        public ActionResult Create()
        {
            ViewBag.MedicalProfileTypeId = new SelectList(db.MedicalProfileTypes, "MedicalProfileTypeId", "Name");
            return View();
        }

        //
        // POST: /MedicalProfileTemplate/Create

        [HttpPost]
        public ActionResult Create(MedicalProfileTemplate medicalrecordtemplate)
        {
            if (ModelState.IsValid)
            {
                db.MedicalProfileTemplates.Add(medicalrecordtemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicalProfileTypeId = new SelectList(db.MedicalProfileTypes, "MedicalProfileTypeId", "Name", medicalrecordtemplate.MedicalProfileTypeId);
            return View(medicalrecordtemplate);
        }

        //
        // GET: /MedicalProfileTemplate/Edit/5

        public JObject Edit(string jsonString, int id)
        {
            var listCustomSnippets = db.CustomSnippets.Where(s => s.MedicalProfileTemplateId == id);
            foreach (var entity in listCustomSnippets)
            {
                db.CustomSnippets.Remove(entity);
            }
            db.SaveChanges();


            JArray listSnippets = JArray.Parse(jsonString) as JArray;

            foreach (dynamic snippet in listSnippets)
            {
                CustomSnippet customSnippet = new CustomSnippet { Title = snippet.title, MedicalProfileTemplateId = id };
                customSnippet.CustomSnippetFields = new Collection<CustomSnippetField>();

                if (snippet.fields != null)
                {
                    foreach (dynamic snippetField in snippet.fields)
                    {
                        //string str = ((object)snippetField).ToString();
                        //Debug.WriteLine("1" + str);

                        dynamic metadata = snippetField.Value;
                        //str = ((object)metadata).ToString();
                        CustomSnippetField customSnippetField = new CustomSnippetField
                        {
                            CustomSnippet = customSnippet,
                            FieldName = snippetField.Name,
                            Label = metadata.label,
                            Type = metadata.type,
                            Value = ((object)metadata.value).ToString(),
                            Name = metadata.name
                        };
                        customSnippet.CustomSnippetFields.Add(customSnippetField);
                    }
                }
                db.CustomSnippets.Add(customSnippet);
                db.SaveChanges();
            }
            dynamic result = new JObject();
            result.status = "success";
            return result;
        }

        //
        // GET: /MedicalProfileTemplate/Delete/5

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