using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using System.ComponentModel;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Security.Controllers
{
    public class CustomFormController : BaseController
    {
        OMCSDBContext Context = new OMCSDBContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JObject SaveCustomForm(string jsonString)
        {
            var listCustomSnippets = Context.CustomSnippets.Where(s => s.MedicalProfileTemplateId == 2);
            foreach (var entity in listCustomSnippets) 
            {
                Context.CustomSnippets.Remove(entity);
            }
            Context.SaveChanges();
            
            
            JArray listSnippets = JArray.Parse(jsonString) as JArray;

            foreach (dynamic snippet in listSnippets)
            {
                CustomSnippet customSnippet = new CustomSnippet { Title = snippet.title, MedicalProfileTemplateId=2 };
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
                Context.CustomSnippets.Add(customSnippet);
                Context.SaveChanges();
            }
            dynamic result = new JObject();
            result.status = "success";
            return result;
        }

        //[HttpPost]
        public JArray ViewCustomFormJson(int medicalProfileTemplateId)
        {
            var listCustomSnippets = Context.CustomSnippets.Where(s => s.MedicalProfileTemplateId == medicalProfileTemplateId).ToList();
            dynamic result = new JArray();
            foreach (var customSnippet in listCustomSnippets)
            {
                dynamic snippet = new JObject();
                snippet.title = customSnippet.Title;
                snippet.fields = new JObject() as dynamic;
                var listCustomSnippetFields = from snippetField in Context.CustomSnippetFields
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
    }
}