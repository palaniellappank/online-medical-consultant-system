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
using OMCS.BLL.Utils;

namespace OMCS.BLL
{
    public class CustomSnippetBusiness : BaseBusiness
    {
        public CustomSnippetBusiness(OMCSDBContext _db)
        {
            this._db = _db;
        }

        /*
         * Get mapping type for a static information, to detect if mapping
         * directly with lastest information from patient or just copy value
         */
        public string GetMappingType(CustomSnippet customSnippet)
        {
            var customSnippetFields = customSnippet.CustomSnippetFields.ToList();
            var mappingType = customSnippetFields.Where(x => x.FieldName == "mappingtype").FirstOrDefault();
            if (mappingType != null) {
                JArray mappingTypeList = JArray.Parse(mappingType.Value);
                foreach (dynamic type in mappingTypeList)
                {
                    if (type.selected) return type.value;
                }
            }
            return "";
        }

        public string GetValueForSnippet(CustomSnippet customSnippet, int patientId, int medicalProfileId)
        {
            string value = "";

            //First, try to get data from CustomSnippetValue
            var customSnippetValue = _db.CustomSnippetValues.Where(
                        x => (x.CustomSnippetId == customSnippet.CustomSnippetId)
                        && (x.MedicalProfileId == medicalProfileId)).FirstOrDefault();
            if (customSnippetValue == null)
            {
                customSnippetValue = new CustomSnippetValue
                {
                    CustomSnippet = customSnippet,
                    MedicalProfileId = medicalProfileId
                };
                _db.CustomSnippetValues.Add(customSnippetValue);
                _db.SaveChanges();
            }
            value = customSnippetValue.Value;

            var user = _db.Users.Where(pa => pa.UserId == patientId).SingleOrDefault();
            var patient = _db.Patients.Where(pa => pa.UserId == patientId).SingleOrDefault();
            var personalHealthRecord = _db.PersonalHealthRecords.Where(pa => pa.PatientId == patientId).SingleOrDefault();
            //Use reflection to get binding data
            if (customSnippet.SnippetType != SnippetType.Custom && String.IsNullOrEmpty(value))
            {
                value = "";
                switch (customSnippet.SnippetType)
                {
                    case SnippetType.User:
                        Type type = typeof(User);
                        object valueProperty;
                        if (customSnippet.SnippetFieldName.Equals("Age"))
                        {
                            valueProperty = type.GetProperty
                                ("Birthday", BindingFlags.IgnoreCase
                                | BindingFlags.Public
                                | BindingFlags.Instance).GetValue(user, null);
                            if (valueProperty != null)
                            {
                                value = valueProperty.ToString();
                                var birthday = DateTime.Parse(value.ToString());
                                value = DateTimeUtils.CalculateAge(birthday).ToString();
                            }
                        }
                        else
                        {
                            valueProperty = type.GetProperty
                                (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase
                                | BindingFlags.Public
                                | BindingFlags.Instance).GetValue(user, null);
                            if (valueProperty != null)
                            {
                                value = valueProperty.ToString();
                                if ("Gender".Equals(customSnippet.SnippetFieldName))
                                {
                                    value = "Nam".Equals(value) ? "Nam" : "Nữ";
                                }
                                if (customSnippet.SnippetFieldName.Equals("Birthday"))
                                {
                                    var birthday = DateTime.Parse(value.ToString());
                                    value = birthday.ToString("dd/MM/yyyy");
                                }
                            }
                        }
                        break;
                    case SnippetType.Patient:
                        type = typeof(Patient);
                        valueProperty = type.GetProperty
                            (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase
                            | BindingFlags.Public
                            | BindingFlags.Instance).GetValue(patient, null);
                        if (valueProperty != null) {
                            value = valueProperty.ToString();
                        }
                        break;
                    case SnippetType.PersonalHealthRecord:
                        type = typeof(PersonalHealthRecord);
                        valueProperty = type.GetProperty
                            (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase
                            | BindingFlags.Public
                            | BindingFlags.Instance).GetValue(personalHealthRecord, null);
                        if (valueProperty != null)
                        {
                            value = valueProperty.ToString();
                        }
                        break;
                }
            }
            return value;
        }

        public List<CustomSnippet> ConvertJsonStringToCustomSnippetList(string jsonString, MedicalProfileTemplate template)
        {
            List<CustomSnippet> resultCustomSnippetList = new List<CustomSnippet>();
            
            JArray listSnippets = JArray.Parse(jsonString) as JArray;
            int position = 0;
            foreach (dynamic snippet in listSnippets)
            {
                CustomSnippet customSnippet = new CustomSnippet { Title = snippet.title, 
                    Name = snippet.name,
                    MedicalProfileTemplateId = template.MedicalProfileTemplateId };
                
                /*
                 * This is for mapping one-one attribute
                 * we don't need to track it
                 */
                if (snippet.title == "Static Text")
                {
                    var SnippetTypeDic = new Dictionary<string, SnippetType> {
                        { "Custom", SnippetType.Custom },
                        { "User", SnippetType.User },
                        { "Patient", SnippetType.Patient },
                        { "PersonalHealthRecord", SnippetType.PersonalHealthRecord }
                    };
                    string str = ((object)snippet.snippettype).ToString();
                    customSnippet.SnippetType = SnippetTypeDic[((object)snippet.snippettype).ToString()];
                    customSnippet.SnippetFieldName = snippet.fieldname;
                }
                position++;
                if (snippet.parentId != null)
                {
                    customSnippet.ParentId = snippet.parentId;
                    customSnippet.PositionInTable = snippet.positionInTable;
                }
                customSnippet.Position = position;
                resultCustomSnippetList.Add(customSnippet);
                customSnippet.CustomSnippetFields = new Collection<CustomSnippetField>();
                if (snippet.fields != null)
                {
                    foreach (dynamic snippetField in snippet.fields)
                    {
                        dynamic metadata = snippetField.Value;

                        if ("id".Equals(snippetField.Name))
                        {
                            if (metadata.value == null)
                                customSnippet.CustomSnippetId = 0;
                            else
                                customSnippet.CustomSnippetId = metadata.value;
                        }

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
            }
            return resultCustomSnippetList;
        }

        public JObject CompareChanges(List<CustomSnippet> snippetDB, List<CustomSnippet> snippetChanged, MedicalProfileTemplate template)
        {
            var numChangeStaticItem = 0;
            var numChangeDynamicItem = 0;
            var numDeleteStaticItem = 0;
            var numDeleteDynamicItem = 0;
            var numMedicalProfileUsage = _db.MedicalProfiles.Where(
                x => x.MedicalProfileTemplateId == template.MedicalProfileTemplateId).Count();
            dynamic changedList = new JArray();
            dynamic removeList = new JArray();

            //Loop to find which item have been changed
            foreach (CustomSnippet snippetChangeItem in snippetChanged)
            {
                //Existing item
                if (snippetChangeItem.CustomSnippetId > 0)
                {
                    var existItem = snippetDB.Where(x => x.CustomSnippetId == snippetChangeItem.CustomSnippetId).Single();
                    
                    /* 
                     * Mapping one-one data
                     * Change it not affect data
                     */
                    if (existItem.Title.Equals("Static Text") || existItem.Title.Equals("Form Name"))
                    {
                        for (int i = 0; i < existItem.CustomSnippetFields.Count; i++)
                        {
                            string fieldName = existItem.CustomSnippetFields.ElementAt(i).FieldName;
                            string oldValue = existItem.CustomSnippetFields.ElementAt(i).Value;
                            string newValue = snippetChangeItem.CustomSnippetFields.ElementAt(i).Value;
                            if (!oldValue.Equals(newValue) && !fieldName.Equals("id"))
                            {
                                dynamic changedItem = new JObject();
                                changedItem.oldValue = oldValue;
                                changedItem.newValue = newValue;
                                changedList.Add(changedItem);
                                numChangeStaticItem++;
                            }
                        }
                    }
                    /*
                     * Custom element
                     * Dangerous when change
                     * Posible to lost data
                     */
                    else
                    {
                        for (int i = 0; i < existItem.CustomSnippetFields.Count; i++)
                        {
                            string fieldName = existItem.CustomSnippetFields.ElementAt(i).FieldName;
                            string oldValue = existItem.CustomSnippetFields.ElementAt(i).Value;
                            string newValue = snippetChangeItem.CustomSnippetFields.ElementAt(i).Value;
                            if (!oldValue.Equals(newValue) && !fieldName.Equals("id"))
                            {
                                dynamic changedItem = new JObject();
                                changedItem.oldValue = oldValue;
                                changedItem.newValue = newValue;
                                changedList.Add(changedItem);
                                numChangeDynamicItem++;
                            }
                        }
                    }
                }
            }

            //Loop to file which item have been removed
            foreach (CustomSnippet snippetExistItem in snippetDB)
            {
                var snippetChangedItem = snippetChanged.Where(x => x.CustomSnippetId == snippetExistItem.CustomSnippetId).SingleOrDefault();
                
                /* This element have been removed
                 * in the list
                 * really dangerous
                 */
                if (snippetChangedItem == null)
                {
                    dynamic removedItem = new JObject();
                    string oldValue = snippetExistItem.CustomSnippetFields.Where(
                        x => (x.FieldName.Equals("label")
                         || x.FieldName.Equals("name")))
                        .FirstOrDefault().Value;
                    removedItem.oldValue = oldValue;
                    removeList.Add(removedItem);

                    if (snippetExistItem.Title.Equals("Static Text") || snippetExistItem.Title.Equals("Form Name"))
                        numDeleteStaticItem++;
                    else
                        numDeleteDynamicItem++;
                }
            }

            dynamic result = new JObject();
            result.numChangeStaticItem = numChangeStaticItem;
            result.numChangeDynamicItem = numChangeDynamicItem;
            result.numDeleteStaticItem = numDeleteStaticItem;
            result.numDeleteDynamicItem = numDeleteDynamicItem;
            result.changedList = changedList;
            result.removeList = removeList;
            result.numMedicalProfileUsage = numMedicalProfileUsage;
            return result;
        }

        public void SaveSnippetList(List<CustomSnippet> snippetDB, List<CustomSnippet> snippetChanged, MedicalProfileTemplate template)
        {
            //Loop to file which item have been changed
            foreach (CustomSnippet snippetChangeItem in snippetChanged)
            {
                //Existing item
                if (snippetChangeItem.CustomSnippetId > 0)
                {
                    var existItem = snippetDB.Where(x => x.CustomSnippetId == snippetChangeItem.CustomSnippetId).Single();
                    for (int i = 0; i < existItem.CustomSnippetFields.Count; i++)
                    {
                        var oldField = existItem.CustomSnippetFields.ElementAt(i);
                        var newField = snippetChangeItem.CustomSnippetFields.ElementAt(i);
                        oldField.Value = newField.Value;
                        existItem.Position = snippetChangeItem.Position;
                        existItem.ParentId = snippetChangeItem.ParentId;
                        existItem.PositionInTable = snippetChangeItem.PositionInTable;
                    }
                }
                //New added item
                else
                {
                    _db.CustomSnippets.Add(snippetChangeItem);
                }
            }

            //Loop to file which item have been removed
            foreach (CustomSnippet snippetExistItem in snippetDB)
            {
                var snippetChangedItem = snippetChanged.Where(x => x.CustomSnippetId == snippetExistItem.CustomSnippetId).SingleOrDefault();

                if (snippetChangedItem == null)
                {
                    _db.CustomSnippets.Remove(snippetExistItem);
                }
            }
            _db.SaveChanges();

            
            //Store Id to CustomSnippetField
            List<CustomSnippet> snippetLatest = _db.CustomSnippets.Where(
                s => s.MedicalProfileTemplateId == template.MedicalProfileTemplateId)
                .OrderBy(s => s.Position)
                .ToList();
            foreach (CustomSnippet snippetItem in snippetLatest)
            {
                for (int i = 0; i < snippetItem.CustomSnippetFields.Count; i++)
                {
                    var field = snippetItem.CustomSnippetFields.ElementAt(i);
                    if (field.FieldName.Equals("id"))
                    {
                        field.Value = snippetItem.CustomSnippetId.ToString();
                    }
                }
            }
            _db.SaveChanges();
        }
    }
}
