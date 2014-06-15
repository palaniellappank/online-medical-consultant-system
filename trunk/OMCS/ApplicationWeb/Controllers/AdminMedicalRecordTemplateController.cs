using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using System.IO;
using PagedList;
using Security.Controllers;
using OMCS.BLL;

namespace OMCS.Web.Controllers
{
    public class AdminMedicalRecordTemplateController : BaseController
    {
        private MedicalProfileTemplateBusiness business = new MedicalProfileTemplateBusiness();

        public ActionResult Index()
        {
            var specialtyfields = _db.SpecialtyFields.Include(s => s.Parent).OrderBy(s => s.ParentId).ToList();
            var specialtyResult = new List<SpecialtyField>();
            foreach (var specialtyfield in specialtyfields)
            {
                if (specialtyfield.Parent == null)
                {
                    specialtyResult.Add(specialtyfield);
                    foreach (var child in specialtyfields)
                    {
                        if (child.Parent == specialtyfield)
                        {
                            specialtyResult.Add(child);
                        }
                    }
                }
            }
            return View(specialtyResult);
        }
    }
}