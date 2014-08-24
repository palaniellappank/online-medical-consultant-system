using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using Newtonsoft.Json.Linq;

namespace OMCS.Web.Controllers
{
    public class ImmunizationController : BaseController
    {
        public ActionResult List(int medicalProfileId)
        {
            var immunizations = _db.Immunizations.Where(
                x => (x.MedicalProfileId == medicalProfileId))
                .OrderByDescending(x => x.DateImmunized)
                .ToList();
            return PartialView("_List", immunizations);
        }

        public ActionResult ListView(int medicalProfileId)
        {
            var immunizations = _db.Immunizations.Where(
                x => (x.MedicalProfileId == medicalProfileId))
                .OrderByDescending(x => x.DateImmunized)
                .ToList();
            return PartialView("_ListView", immunizations);
        }

        public ActionResult Create(int medicalProfileId)
        {
            var immunization = new Immunization
            {
                MedicalProfileId = medicalProfileId,
                DateImmunized = DateTime.Now
            };
            return PartialView("_Create", immunization);
        }

        [HttpPost]
        public JObject Create(Immunization immunization)
        {
            _db.Immunizations.Add(immunization);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        public ActionResult Edit(int id = 0)
        {
            Immunization immunization = _db.Immunizations.Find(id);
            return PartialView("_Edit", immunization);
        }

        [HttpPost]
        public JObject Edit(Immunization immunization)
        {
            _db.Entry(immunization).State = EntityState.Modified;
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        [HttpPost, ActionName("Delete")]
        public JObject DeleteConfirmed(int id)
        {
            Immunization immunization = _db.Immunizations.Find(id);
            _db.Immunizations.Remove(immunization);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }
    }
}