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
    public class CustomSnippetBusiness : BaseBusiness
    {
        public CustomSnippetBusiness(OMCSDBContext _db)
        {
            this._db = _db;
        }
        public string GetValueForSnippet(CustomSnippet customSnippet, int patientId, int medicalProfileId)
        {
            string value = "";
            var user = _db.Users.Where(pa => pa.UserId == patientId).SingleOrDefault();
            var patient = _db.Patients.Where(pa => pa.UserId == patientId).SingleOrDefault();
            var personalHealthRecord = _db.PersonalHealthRecords.Where(pa => pa.PatientId == patientId).SingleOrDefault();
            //Use reflection to get binding data
            if (customSnippet.SnippetType != SnippetType.Custom)
            {
                switch (customSnippet.SnippetType)
                {
                    case SnippetType.User:
                        Type type = typeof(User);
                        Debug.WriteLine("{0}, User", customSnippet.SnippetFieldName);
                        var valueProperty = type.GetProperty
                            (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase
                            | BindingFlags.Public
                            | BindingFlags.Instance).GetValue(user, null);
                        value = valueProperty.ToString();
                        if (customSnippet.SnippetFieldName.Equals("Birthday"))
                        {
                            var birthday = DateTime.Parse(value.ToString());
                            value = birthday.ToString("dd/MM/yyyy");
                        }
                        break;
                    case SnippetType.Patient:
                        type = typeof(Patient);
                        value = type.GetProperty
                            (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase
                            | BindingFlags.Public
                            | BindingFlags.Instance).GetValue(patient, null).ToString();
                        break;
                    case SnippetType.PersonalHealthRecord:
                        type = typeof(PersonalHealthRecord);
                        value = type.GetProperty
                            (customSnippet.SnippetFieldName, BindingFlags.IgnoreCase
                            | BindingFlags.Public
                            | BindingFlags.Instance).GetValue(personalHealthRecord, null).ToString();
                        break;
                }
            }
            else
            {
                var customSnippetValue = _db.CustomSnippetValues.Where(
                        x => (x.CustomSnippetId == customSnippet.CustomSnippetId)
                        && (x.MedicalProfileId == medicalProfileId)).FirstOrDefault();
                if (customSnippetValue == null)
                {
                    customSnippetValue = new CustomSnippetValue
                    {
                        CustomSnippet = customSnippet
                    };
                    _db.CustomSnippetValues.Add(customSnippetValue);
                    _db.SaveChanges();
                }
                value = customSnippetValue.Value;
            }
            return value;
        }
    }
}
