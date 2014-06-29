using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OMCS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OMCS.BLL
{
    public class MedicalProfileTemplateBusiness: BaseBusiness
    {
        CustomSnippetBusiness snippetBusiness;

        private readonly OMCSDBContext db = new OMCSDBContext();

        public MedicalProfileTemplateBusiness()
        {
            snippetBusiness = new CustomSnippetBusiness(_db);
        }

        public string ShowTemplate(int id)
        {
            var listCustomSnippets = db.CustomSnippets.Where(s => s.MedicalProfileTemplateId == id).ToList();
            dynamic result = new JArray();
            foreach (var customSnippet in listCustomSnippets)
            {
                dynamic snippet = new JObject();
                snippet.title = customSnippet.Title;
                if (snippet.title == "Static Text")
                {
                    snippet.snippettype = customSnippet.SnippetType.ToString();
                    snippet.fieldname = customSnippet.SnippetFieldName;
                }
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
                    if (customSnippetField.Type.Equals("checkbox"))
                    {
                        metadata.value = customSnippetField.Value.Equals("True") ? true : false;
                    }
                    else
                        metadata.value = value;
                    metadata.name = customSnippetField.Name;
                    snippet.fields.Add(customSnippetField.FieldName, metadata);
                }
                result.Add(snippet);
            }
            string json = ((object)result).ToString();
            return json;
        }

        public JObject SaveTemplate(string jsonString, MedicalProfileTemplate template)
        {
            if (template.MedicalProfileTemplateId == 0)
            {
                //Create Mode
                db.MedicalProfileTemplates.Add(template);
                template.MedicalProfileTemplateName = "Mẫu chưa được đặt tên";
                db.SaveChanges();
            }
            else
            {
                //Edit Mode
                //var listCustomSnippets = db.CustomSnippets.Where(s => s.MedicalProfileTemplateId == template.MedicalProfileTemplateId);
                //foreach (var entity in listCustomSnippets)
                //{
                //    db.CustomSnippets.Remove(entity);
                //}
                //db.SaveChanges();
            }

            List<CustomSnippet> snippetChanged = snippetBusiness.ConvertJsonStringToCustomSnippetList(jsonString, template);
            List<CustomSnippet> snippetDB = _db.CustomSnippets.Where(
                s => s.MedicalProfileTemplateId == template.MedicalProfileTemplateId)
                .OrderBy(s=>s.Position)
                .ToList();
            Debug.WriteLine(snippetChanged);
            Debug.WriteLine(snippetDB);
            JObject result = snippetBusiness.CompareChanges(snippetDB, snippetChanged, template);
            return result;
        }

        public JObject CheckTemplateChanged(string jsonString, MedicalProfileTemplate template)
        {
            List<CustomSnippet> snippetChanged = snippetBusiness.ConvertJsonStringToCustomSnippetList(jsonString, template);
            List<CustomSnippet> snippetDB = _db.CustomSnippets.Where(
                s => s.MedicalProfileTemplateId == template.MedicalProfileTemplateId)
                .OrderBy(s => s.Position)
                .ToList();
            JObject result = snippetBusiness.CompareChanges(snippetDB, snippetChanged, template);
            return result;
        }
    }
}
