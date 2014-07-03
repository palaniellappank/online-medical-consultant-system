﻿using OMCS.BLL;
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

        public ActionResult Create(int medicalProfileId)
        {
            var treatmentHistory = new TreatmentHistory
            {
                MedicalProfileId = medicalProfileId,
                DoctorId = User.UserId,
                OnSetDate = DateTime.Now,
                DateCreated = DateTime.Now
            };
            return PartialView("_Create", treatmentHistory);
        }

        [HttpPost]
        public JObject Create(TreatmentHistory treatmentHistory)
        {
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
        public ActionResult Edit(TreatmentHistory treatmentHistory)
        {
            _db.Entry(treatmentHistory).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public JObject DeleteConfirmed(int id)
        {
            TreatmentHistory treatmentHistory = _db.TreatmentHistories.Find(id);
            _db.TreatmentHistories.Remove(treatmentHistory);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }
    }
}