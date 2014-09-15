using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using OMCS.DAL.Model;

namespace OMCS.BLL
{
    public class BaseBusiness
    {
        protected OMCSDBContext _db = new OMCSDBContext();

        protected Doctor GetDoctor(string fromEmail, string toEmail)
        {
            var doctor = _db.Doctors.Where(u => u.Email.Equals(fromEmail)).FirstOrDefault();
            if (doctor == null) doctor = _db.Doctors.Where(u => u.Email.Equals(toEmail)).FirstOrDefault();
            return doctor;
        }

        protected Patient GetPatient(string fromEmail, string toEmail)
        {
            var patient = _db.Patients.Where(u => u.Email.Equals(fromEmail)).FirstOrDefault();
            if (patient == null) patient = _db.Patients.Where(u => u.Email.Equals(toEmail)).FirstOrDefault();
            return patient;
        }
    }
}
