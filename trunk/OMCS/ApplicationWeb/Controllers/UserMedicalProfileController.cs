using Newtonsoft.Json.Linq;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web.Controllers
{
     [CustomAuthorize(Roles= "User")]
    public class UserMedicalProfileController : BaseController
    {
        public ActionResult Index()
        {
            var medicalProfiles = _db.MedicalProfiles.Where(a => a.PatientId == User.UserId).ToList();
            ViewBag.medicalProfiles = medicalProfiles;
            return View(medicalProfiles);
        }
        public JArray Details(int medicalProfileId)
        {
            var medicalProfile = _db.MedicalProfiles.Find(medicalProfileId);
            var snippetList = _db.CustomSnippets.Where
                (x => x.MedicalProfileTemplateId == medicalProfile.MedicalProfileTemplateId)
                .OrderBy(x=>x.Position)
                .ToList();

            dynamic snippetJsonList = new JArray();

            foreach (var snippet in snippetList)
            {
                var snippetFields = _db.CustomSnippetFields.
                    Where(x=>x.CustomSnippetId == snippet.CustomSnippetId).
                    ToList();
                dynamic snippetJsonObject = new JObject();
                foreach (var snippetField in snippetFields) 
                {
                    if (snippetField.FieldName.Equals("name"))
                    {
                        snippetJsonObject.name = snippetField.Value;
                    }
                    if (snippetField.FieldName.Equals("label"))
                    {
                        snippetJsonObject.name = snippetField.Value;
                    }
                }

                var snippetValue = _db.CustomSnippetValues.Where
                    (x=>x.CustomSnippetId == snippet.CustomSnippetId 
                        && x.MedicalProfileId == medicalProfileId).FirstOrDefault();
                if (snippetValue != null)
                {
                    snippetJsonObject.value = snippetValue.Value;
                }
                else
                {
                    snippetJsonObject.value = "";
                }

                snippetJsonList.Add(snippetJsonObject);
            }
            return snippetJsonList;
        }
    }
}