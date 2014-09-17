using OMCS.BLL;
using OMCS.DAL.Model;
using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using OMCS.Web.DTO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Data;

namespace OMCS.Web.Controllers
{
    public class TreatmentHistoryController : BaseController
    {
        private AdminUserBusiness business = new AdminUserBusiness();
        private MedicalProfileBusiness medicalProfileBusiness = new MedicalProfileBusiness();

        public ActionResult List(int medicalProfileId)
        {
            var treatments = _db.TreatmentHistories.Where(
                x => x.MedicalProfileId == medicalProfileId)
                .OrderByDescending(x=>x.DateCreated)
                .ToList();
            return PartialView("_List", treatments);
        }

        public ActionResult ListView(int medicalProfileId)
        {
            var treatments = _db.TreatmentHistories.Where(
                x => x.MedicalProfileId == medicalProfileId)
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            return PartialView("_ListView", treatments);
        }

        public ActionResult Create(int medicalProfileId)
        {
            var treatmentHistory = new TreatmentHistory
            {
                MedicalProfileId = medicalProfileId,
                OnSetDate = DateTime.Now,
                DateCreated = DateTime.Now
            };
            return PartialView("_Create", treatmentHistory);
        }

        [HttpPost]
        public JObject Create(TreatmentHistory treatmentHistory)
        {
            treatmentHistory.DateCreated = DateTime.UtcNow;
            treatmentHistory.DoctorId = User.UserId;
            _db.TreatmentHistories.Add(treatmentHistory);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        public ActionResult Edit(int id = 0)
        {
            TreatmentHistory treatmentHistory = _db.TreatmentHistories.Find(id);
            return PartialView("_Edit", treatmentHistory);
        }

        [HttpPost]
        public JObject Edit(TreatmentHistory treatmentHistory)
        {
            _db.Entry(treatmentHistory).State = EntityState.Modified;
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        [HttpPost, ActionName("Delete")]
        public JObject DeleteConfirmed(int id)
        {
            List<FilmDocument> filmDocuments = _db.FilmDocuments.Where(
                x => x.TreatmentHistoryId == id).ToList();
            filmDocuments.ForEach(x => _db.FilmDocuments.Remove(x));
            TreatmentHistory treatmentHistory = _db.TreatmentHistories.Find(id);
            _db.TreatmentHistories.Remove(treatmentHistory);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        public JArray GetTreatmentHistoryList(string patientEmail, int medicalProfileId = 0)
        {
            List<TreatmentHistory> treatmentHistories = new List<TreatmentHistory>();
            if (medicalProfileId == 0)
            {
                treatmentHistories = _db.TreatmentHistories.
                Where(x => x.MedicalProfile == null).
                OrderByDescending(x => x.DateCreated).ToList();
            }
            else
            {
                treatmentHistories = _db.TreatmentHistories.
                Where(x => x.MedicalProfile.Patient.Email.Equals(patientEmail)
                    && (x.MedicalProfileId == medicalProfileId)).
                OrderByDescending(x => x.DateCreated).ToList();
            }
            
            dynamic treatmentHistoryListJson = new JArray();
            foreach (var treatmentHistory in treatmentHistories)
            {
                dynamic treatmentHistoryJson = new JObject();
                treatmentHistoryJson.id = treatmentHistory.TreatmentHistoryId;
                treatmentHistoryJson.text = treatmentHistory.DateCreated.ToShortDateString();
                treatmentHistoryListJson.Add(treatmentHistoryJson);
            }
            return treatmentHistoryListJson;
        }

        public JArray GetAllTreatmentHistoryList(string patientEmail)
        {
            var treatmentHistories = _db.TreatmentHistories.
                Where(x => x.MedicalProfile.Patient.Email.Equals(patientEmail) || x.Patient.Email.Equals(patientEmail)).
                OrderByDescending(x => x.DateCreated).ToList();
            dynamic treatmentHistoryListJson = new JArray();
            foreach (var treatmentHistory in treatmentHistories)
            {
                dynamic treatmentHistoryJson = new JObject();
                treatmentHistoryJson.id = treatmentHistory.TreatmentHistoryId;
                if (treatmentHistory.MedicalProfile != null)
                {
                    treatmentHistoryJson.medicalRecordName = treatmentHistory.MedicalProfile.MedicalProfileTemplate.MedicalProfileTemplateName;
                    treatmentHistoryJson.medicalRecordId = treatmentHistory.MedicalProfile.MedicalProfileId;
                }
                treatmentHistoryJson.symptom = treatmentHistory.Symptom;
                treatmentHistoryJson.diagnosis = treatmentHistory.Diagnosis;
                treatmentHistoryJson.treatment = treatmentHistory.Treatment;
                treatmentHistoryJson.condition = treatmentHistory.Condition;
                treatmentHistoryJson.dateCreated = treatmentHistory.DateCreated.ToShortDateString();
                treatmentHistoryListJson.Add(treatmentHistoryJson);
            }
            return treatmentHistoryListJson;
        }
    }
}