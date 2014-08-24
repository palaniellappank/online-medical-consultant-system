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
    public class MedicalProfileBusiness : BaseBusiness
    {
        CustomSnippetBusiness snippetBusiness;

        public MedicalProfileBusiness()
        {
            snippetBusiness = new CustomSnippetBusiness(_db);
        }

        /*
         * This function help doctor to get a medical template
         * and get data binding to field
         */
        public string UpdateMedicalProfile(int patientId, int medicalProfileTemplateId)
        {
            var medicalProfile = _db.MedicalProfiles.Where(
                mp => ((mp.PatientId == patientId) &&
                    (mp.MedicalProfileTemplateId == medicalProfileTemplateId))
            ).FirstOrDefault();
            if (medicalProfile == null)
            {
                medicalProfile = new MedicalProfile
                {
                    PatientId = patientId,
                    MedicalProfileTemplateId = medicalProfileTemplateId,
                    CreatedDate = DateTime.UtcNow
                };
                _db.MedicalProfiles.Add(medicalProfile);
                _db.SaveChanges();
            }
            var listCustomSnippets = _db.CustomSnippets.Where(
                s => s.MedicalProfileTemplateId == medicalProfileTemplateId
                ).OrderBy(s => s.Position)
                .ToList();
            dynamic result = new JArray();
            foreach (var customSnippet in listCustomSnippets)
            {
                dynamic snippet = new JObject();
                snippet.title = customSnippet.Title;
                if (customSnippet.ParentId != 0)
                {
                    snippet.parentId = customSnippet.ParentId;
                    snippet.positionInTable = customSnippet.PositionInTable;
                }
                snippet.fields = new JObject() as dynamic;
                Debug.WriteLine(customSnippet.SnippetType);

                var listCustomSnippetFields = from snippetField in _db.CustomSnippetFields
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

                //valueStatic is use to get mapping data from User, HealthRecord data
                dynamic metadataValue = new JObject();
                metadataValue.value = snippetBusiness.GetValueForSnippet(customSnippet, patientId, medicalProfile.MedicalProfileId);
                snippet.fields.Add("value", metadataValue);
                result.Add(snippet);
            }
            string str = ((object)result).ToString();
            return str;
        }

        /*
         * This function help to get medical profile detail to view
         * and get data binding to field
         */
        public string ViewMedicalProfile(int patientId, int medicalProfileTemplateId)
        {
            return UpdateMedicalProfile(patientId, medicalProfileTemplateId);
        }

        public void UpdateMedicalProfileForPatient(FormCollection formCollection)
        {
            int medicalProfileTemplateId = Int32.Parse(formCollection["medicalProfileTemplateId"]);
            int patientId = Int32.Parse(formCollection["patientId"]);
            var medicalProfile = _db.MedicalProfiles.Where(
                    x => ((x.MedicalProfileTemplateId == medicalProfileTemplateId)
                    && (x.PatientId == patientId))).FirstOrDefault();
            foreach (string _formData in formCollection)
            {
                if (!_formData.Equals("medicalProfileTemplateId") && !_formData.Equals("patientId"))
                {
                    Debug.WriteLine("Element: " + _formData + ". Form data: " + formCollection[_formData]);
                    int customSnippetId = Int32.Parse(_formData);
                    if (customSnippetId > 0)
                    {
                        var customSnippetValue = _db.CustomSnippetValues.Where(
                            x => (x.CustomSnippetId == customSnippetId)
                                && (x.MedicalProfileId == medicalProfile.MedicalProfileId)
                            ).FirstOrDefault();
                        if (customSnippetValue == null)
                        {
                            customSnippetValue = new CustomSnippetValue
                            {
                                MedicalProfileId = medicalProfile.MedicalProfileId,
                                CustomSnippetId = customSnippetId
                            };
                            _db.CustomSnippetValues.Add(customSnippetValue);
                        }
                        string[] value = formCollection.GetValues(_formData);
                        if (value.Length == 1)
                        {
                            customSnippetValue.Value = value[0];
                        }
                        else
                        {
                            customSnippetValue.Value = String.Join("~~", value);
                        }
                        _db.SaveChanges();
                    }
                }
            }
        }

        public void SearchByStringMedical(string searchString, ref IEnumerable<MedicalProfile> medical)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                medical = medical.Where(u => (!String.IsNullOrWhiteSpace(u.MedicalProfileKey) && (u.MedicalProfileKey.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.Patient.FullName) && (u.Patient.FullName.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.MedicalProfileTemplate.MedicalProfileTemplateName) && (u.MedicalProfileTemplate.MedicalProfileTemplateName.ToUpper().Contains(searchString.ToUpper()))));
            }
        }

        public void CheckSortOrderMedical(string sortOrder, ref IEnumerable<MedicalProfile> medical)
        {
            switch (sortOrder)
            {
                case "User_desc":
                    medical = medical.OrderByDescending(u => u.Patient.Email);
                    break;
                case "Date":
                    medical = medical.OrderBy(u => u.CreatedDate);
                    break;
                case "Date_desc":
                    medical = medical.OrderByDescending(u => u.CreatedDate);
                    break;
                case "Name":
                    medical = medical.OrderBy(u => u.Patient.FullName);
                    break;
                case "Name_desc":
                    medical = medical.OrderByDescending(u => u.Patient.FullName);
                    break;
                case "MedicalProfileKey":
                    medical = medical.OrderBy(u => u.MedicalProfileKey);
                    break;
                case "MedicalProfileKey_desc":
                    medical = medical.OrderByDescending(u => u.MedicalProfileKey);
                    break;
                case "MedicalProfileName":
                    medical = medical.OrderBy(u => u.MedicalProfileTemplate.MedicalProfileTemplateName);
                    break;
                case "MedicalProfileName_desc":
                    medical = medical.OrderByDescending(u => u.MedicalProfileTemplate.MedicalProfileTemplateName);
                    break;
                default:
                    medical = medical.OrderBy(u => u.Patient.Email);
                    break;
            }
        }
    }
}
