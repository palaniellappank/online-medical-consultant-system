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
    public class FilmDocumentController : BaseController
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

        public ActionResult Create(int treatmentHistoryId)
        {
            var filmTypeList = _db.FilmTypes.ToList();
            ViewBag.FilmTypeId = new SelectList(filmTypeList, "FilmTypeId", "Name");
            var filmDocument = new FilmDocument
            {
                TreatmentHistoryId = treatmentHistoryId,
                DoctorId = User.UserId
            };
            return PartialView("_Create", filmDocument);
        }

        [HttpPost]
        public JObject Create(FilmDocument filmDocument, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = DateTime.Now.Millisecond + "_" + Path.GetFileName(file.FileName);
                var path = HttpContext.Server.MapPath("~/Content/Image/FilmDocument/" + fileName);
                var dbPath = fileName;
                file.SaveAs(path);
                filmDocument.ImagePath = dbPath;
            }
            filmDocument.DateCreated = DateTime.Now;

            _db.FilmDocuments.Add(filmDocument);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        public ActionResult Edit(int id = 0)
        {
            FilmDocument filmDocument = _db.FilmDocuments.Find(id);
            var filmTypeList = _db.FilmTypes.ToList();
            ViewBag.FilmTypeId = new SelectList(filmTypeList, "FilmTypeId", "Name", filmDocument.FilmTypeId);
            return PartialView("_Edit", filmDocument);
        }

        [HttpPost]
        public JObject Edit(FilmDocument filmDocument, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = DateTime.Now.Millisecond + "_" + Path.GetFileName(file.FileName);
                var path = HttpContext.Server.MapPath("~/Content/Image/FilmDocument/" + fileName);
                var dbPath = fileName;
                file.SaveAs(path);
                filmDocument.ImagePath = dbPath;
            }
            _db.Entry(filmDocument).State = EntityState.Modified;
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }

        [HttpPost, ActionName("Delete")]
        public JObject DeleteConfirmed(int id)
        {
            FilmDocument filmDocument = _db.FilmDocuments.Find(id);
            _db.FilmDocuments.Remove(filmDocument);
            _db.SaveChanges();
            dynamic result = new JObject();
            result.result = "ok";
            return result;
        }
    }
}