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
using System.IO;

namespace OMCS.Web.Controllers
{
    public class AllergyController : BaseController
    {
        public ActionResult List(int medicalProfileId)
        {
            var allergies = _db.Allergies.Where(
                x => (x.MedicalProfileId == medicalProfileId))
                .OrderByDescending(x => x.AllergyId)
                .OrderByDescending(x => x.DateLastOccurred)
                .ToList();
            return PartialView("_List", allergies);
        }

        public ActionResult ListView(int medicalProfileId)
        {
            var allergies = _db.Allergies.Where(
                x => (x.MedicalProfileId == medicalProfileId))
                .OrderByDescending(x => x.AllergyId)
                .OrderByDescending(x => x.DateLastOccurred)
                .ToList();
            return PartialView("_ListView", allergies);
        }

        public ActionResult Create(int medicalProfileId)
        {
            var allergyType = _db.AllergyTypes.ToList();
            ViewBag.AllergyTypeId = new SelectList(allergyType, "AllergyTypeId", "Name");

            var allergy = new Allergy
            {
                MedicalProfileId = medicalProfileId
            };
            return PartialView("_Create", allergy);
        }

        [HttpPost]
        public JObject Create(Allergy allergy)
        {
            _db.Allergies.Add(allergy);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        public ActionResult Edit(int id = 0)
        {
            Allergy allergy = _db.Allergies.Find(id);
            var allergyType = _db.AllergyTypes.ToList();
            ViewBag.AllergyTypeId = new SelectList(allergyType, "AllergyTypeId", "Name", allergy.AllergyTypeId);
            return PartialView("_Edit", allergy);
        }

        public ActionResult Details(int id = 0)
        {
            Allergy allergy = _db.Allergies.Find(id);
            var allergyType = _db.AllergyTypes.ToList();
            ViewBag.AllergyTypeId = new SelectList(allergyType, "AllergyTypeId", "Name", allergy.AllergyTypeId);
            return PartialView("_Details", allergy);
        }

        [HttpPost]
        public JObject Edit(Allergy allergy)
        {
            _db.Entry(allergy).State = EntityState.Modified;
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        [HttpPost, ActionName("Delete")]
        public JObject DeleteConfirmed(int id)
        {
            Allergy allergy = _db.Allergies.Find(id);
            _db.Allergies.Remove(allergy);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }
    }
}