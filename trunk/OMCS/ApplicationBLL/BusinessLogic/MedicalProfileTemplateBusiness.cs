﻿using Newtonsoft.Json;
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

namespace OMCS.BLL
{
    public class MedicalProfileTemplateBusiness: BaseBusiness
    {
        private readonly OMCSDBContext db = new OMCSDBContext();

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
                    metadata.value = value;
                    metadata.name = customSnippetField.Name;
                    snippet.fields.Add(customSnippetField.FieldName, metadata);
                }
                result.Add(snippet);
            }
            string json = JsonConvert.SerializeObject(result, Formatting.None);
            return json;
        }

        public void SaveTemplate(string jsonString, MedicalProfileTemplate template)
        {
            if (template.MedicalProfileTemplateId == 0)
            {
                //Create Mode
                db.MedicalProfileTemplates.Add(template);
                template.MedicalProfileTemplateName = "Su Tran";
                db.SaveChanges();
                Debug.WriteLine("Su Tran" + template.MedicalProfileTemplateId);
            }
            else
            {
                //Edit Mode
                var listCustomSnippets = db.CustomSnippets.Where(s => s.MedicalProfileTemplateId == template.MedicalProfileTemplateId);
                foreach (var entity in listCustomSnippets)
                {
                    db.CustomSnippets.Remove(entity);
                }
                db.SaveChanges();
            }
            

            JArray listSnippets = JArray.Parse(jsonString) as JArray;

            foreach (dynamic snippet in listSnippets)
            {
                CustomSnippet customSnippet = new CustomSnippet { Title = snippet.title, MedicalProfileTemplateId = template.MedicalProfileTemplateId };
                
                if (snippet.title == "Static Text")
                {
                    var SnippetTypeDic = new Dictionary<string, SnippetType> {
                        { "Custom", SnippetType.Custom },
                        { "User", SnippetType.User },
                        { "Patient", SnippetType.Patient },
                        { "PersonalHealthRecord", SnippetType.PersonalHealthRecord }
                    };
                    string str = ((object)snippet.snippettype).ToString();
                    Debug.WriteLine("1" + str);
                    customSnippet.SnippetType = SnippetTypeDic[((object)snippet.snippettype).ToString()];
                    customSnippet.SnippetFieldName = snippet.fieldname;
                }

                db.CustomSnippets.Add(customSnippet);
                db.SaveChanges();
                customSnippet.CustomSnippetFields = new Collection<CustomSnippetField>();
                if (snippet.fields != null)
                {
                    foreach (dynamic snippetField in snippet.fields)
                    {
                        //string str = ((object)snippetField).ToString();
                        //Debug.WriteLine("1" + str);
                        dynamic metadata = snippetField.Value;

                        if ("id".Equals(snippetField.Name))
                        {
                            metadata.value = customSnippet.CustomSnippetId;
                        }
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
                db.Entry(customSnippet).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public string UpdateMedicalProfile(int id, int medicalProfileTemplateId)
        {
            var medicalProfile = _db.MedicalProfiles.Where(
                mp => ((mp.PatientId == id) &&
                    (mp.MedicalProfileTemplateId == medicalProfileTemplateId))
            ).FirstOrDefault();
            if (medicalProfile == null)
            {
                _db.MedicalProfiles.Add(new MedicalProfile
                {
                    PatientId = id,
                    MedicalProfileTemplateId = medicalProfileTemplateId,
                    CreatedDate = DateTime.UtcNow
                });
                _db.SaveChanges();
            }
            var listCustomSnippets = _db.CustomSnippets.Where(
                s => s.MedicalProfileTemplateId == medicalProfileTemplateId
            ).ToList();
            dynamic result = new JArray();
            foreach (var customSnippet in listCustomSnippets)
            {
                dynamic snippet = new JObject();
                snippet.title = customSnippet.Title;
                snippet.fields = new JObject() as dynamic;
                Debug.WriteLine(customSnippet.SnippetType);
                var valueStatic = "";
                if (customSnippet.SnippetType != SnippetType.Custom)
                {
                    switch (customSnippet.SnippetType)
                    {
                        case SnippetType.User:
                            var user = _db.Users.Where(pa => pa.UserId == id).SingleOrDefault();
                            Type type = typeof(User);
                            valueStatic = type.GetProperty
                                (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase 
                                | BindingFlags.Public 
                                | BindingFlags.Instance).GetValue(user,null).ToString();
                            break;
                        case SnippetType.Patient:
                            var patient = _db.Patients.Where(pa => pa.UserId == id).SingleOrDefault();
                            type = typeof(Patient);
                            valueStatic = type.GetProperty
                                (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase 
                                | BindingFlags.Public
                                | BindingFlags.Instance).GetValue(patient, null).ToString();
                            break;
                        case SnippetType.PersonalHealthRecord:
                            var personalHealthRecord = _db.PersonalHealthRecords.Where(pa => pa.PatientId == id).SingleOrDefault();
                            type = typeof(PersonalHealthRecord);
                            valueStatic = type.GetProperty
                                (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase 
                                | BindingFlags.Public
                                | BindingFlags.Instance).GetValue(personalHealthRecord, null).ToString();
                            break;
                    }
                   // Debug.WriteLine(snippet.value);
                }
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
                if (!String.IsNullOrEmpty(valueStatic))
                {
                    dynamic metadata = new JObject();
                    metadata.value = valueStatic;
                    snippet.fields.Add("value", metadata);
                }
                result.Add(snippet);
            }
            Debug.WriteLine("Haha ne");
            string str = ((object)result).ToString();
            return str;
        }
    }
}
