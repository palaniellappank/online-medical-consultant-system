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
using ApplicationBLL.Utils;

namespace OMCS.Web.Controllers
{
    public class FilmDocumentController : BaseController
    {
        public ActionResult List(int medicalProfileId)
        {
            var filmDocuments = _db.FilmDocuments.Where(
                x => (x.MedicalProfileId.HasValue && x.MedicalProfileId.Value == medicalProfileId)
                    || (x.TreatmentHistory != null && x.TreatmentHistory.MedicalProfileId == medicalProfileId))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            return PartialView("_List", filmDocuments);
        }

        public ActionResult ListView(int medicalProfileId)
        {
            var filmDocuments = _db.FilmDocuments.Where(
                x => (x.MedicalProfileId.HasValue && x.MedicalProfileId.Value == medicalProfileId)
                    || (x.TreatmentHistory != null && x.TreatmentHistory.MedicalProfileId == medicalProfileId))
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            return PartialView("_ListView", filmDocuments);
        }

        public ActionResult CreateWhenChat(string patientEmail)
        {
            var filmTypeList = _db.FilmTypes.ToList();
            ViewBag.FilmTypeId = new SelectList(filmTypeList, "FilmTypeId", "Name");
            var filmDocument = new FilmDocument
            {
                DoctorId = User.UserId
            };
            return PartialView("_CreateWhenChat", filmDocument);
        }

        public ActionResult CreateForTreatment(int treatmentHistoryId)
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

        public ActionResult CreateForMedicalProfile(int medicalProfileId)
        {
            var filmTypeList = _db.FilmTypes.ToList();
            ViewBag.FilmTypeId = new SelectList(filmTypeList, "FilmTypeId", "Name");
            var filmDocument = new FilmDocument
            {
                MedicalProfileId = medicalProfileId,
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

        [HttpPost]
        public JObject CreateFromWebcam(FilmDocument filmDocument, string imgBase64)
        {
            imgBase64 = imgBase64.Split(',')[1];
            var file = ImageToString.GetImageFromString(imgBase64);
            if (file != null)
            {
                var fileName = DateTime.Now.Millisecond + ".png";
                var path = HttpContext.Server.MapPath("~/Content/Image/FilmDocument/" + fileName);
                var dbPath = fileName;
                file.Save(path);
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

        public ActionResult Details(int id = 0)
        {
            FilmDocument filmDocument = _db.FilmDocuments.Find(id);
            return PartialView("_Details", filmDocument);
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