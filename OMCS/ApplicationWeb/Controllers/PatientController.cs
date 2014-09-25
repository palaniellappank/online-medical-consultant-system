using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMCS.DAL.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace OMCS.Web.Controllers
{
    public class PatientController : BaseController
    {
        public JArray SearchPatient(string keyword)
        {
            IEnumerable<Patient> patientsDB = _db.Patients.ToList();
            dynamic patientsJson = new JArray();

            //Check Search String to search by UserName/FullName
            var patients = patientsDB.Where(u => (!String.IsNullOrWhiteSpace(u.Email) && (u.Email.ToUpper().Contains(keyword.ToUpper())))
                    || (!String.IsNullOrWhiteSpace(u.FullName) && (u.FullName.ToUpper().Contains(keyword.ToUpper())))
                    || (!String.IsNullOrWhiteSpace(u.Phone) && (u.Phone.ToUpper().Contains(keyword.ToUpper())))).Take(5).ToList();

            foreach (var patient in patients)
            {
                dynamic patientJson = new JObject();
                patientJson.profilePicture = patient.ProfilePicture;
                patientJson.fullName = patient.FullName;
                patientJson.email = patient.Email;
                patientJson.phone = patient.Phone;
                patientsJson.Add(patientJson);
            }

            return patientsJson;
        }
    }
}