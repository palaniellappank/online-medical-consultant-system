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
    public class AdminUserBusiness : BaseBusiness
    {
        //Check the Sort Order to sort with corresponding column
        public void CheckSortOrder(string sortOrder, ref IEnumerable<User> users)
        {
            switch (sortOrder)
            {
                case "User_desc":
                    users = users.OrderByDescending(u => u.Email);
                    break;
                case "Date":
                    users = users.OrderBy(u => u.CreatedDate);
                    break;
                case "Date_desc":
                    users = users.OrderByDescending(u => u.CreatedDate);
                    break;
                case "Active":
                    users = users.OrderBy(u => u.IsActive);
                    break;
                case "Active_desc":
                    users = users.OrderByDescending(u => u.IsActive);
                    break;
                case "Name":
                    users = users.OrderBy(u => u.FullName);
                    break;
                case "Name_desc":
                    users = users.OrderByDescending(u => u.FullName);
                    break;
                case "Phone":
                    users = users.OrderBy(u => u.Phone);
                    break;
                case "Phone_desc":
                    users = users.OrderByDescending(u => u.Phone);
                    break;
                default:
                    users = users.OrderBy(u => u.Email);
                    break;
            }
        }

        //Check Search String to search by UserName/FullName
        public void SearchByString(string searchString, ref IEnumerable<User> users)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => (!String.IsNullOrWhiteSpace(u.Email) && (u.Email.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.FullName) && (u.FullName.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.Phone) && (u.Phone.ToUpper().Contains(searchString.ToUpper()))));
            }
        }

        public void SearchByStringMedical(string searchString, ref IEnumerable<MedicalProfile> medical)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                medical = medical.Where(u => (!String.IsNullOrWhiteSpace(u.MedicalProfileKey) && (u.MedicalProfileKey.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.Patient.FullName) && (u.Patient.FullName.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.MedicalProfileTemplate.MedicalProfileTemplateName) && (u.MedicalProfileTemplate.MedicalProfileTemplateName.ToUpper().Contains(searchString.ToUpper()))));
            }
        }

        public void CheckSortOrderMedical(string sortOrder, ref IEnumerable<MedicalProfile> medical)
        {
            switch (sortOrder)
            {
                case "User_desc":
                    medical = medical.OrderByDescending(u => u.Patient.Email);
                    break;
                case "Date":
                    medical = medical.OrderBy(u => u.CreatedDate);
                    break;
                case "Date_desc":
                    medical = medical.OrderByDescending(u => u.CreatedDate);
                    break;
                case "Name":
                    medical = medical.OrderBy(u => u.Patient.FullName);
                    break;
                case "Name_desc":
                    medical = medical.OrderByDescending(u => u.Patient.FullName);
                    break;
                case "MedicalProfileKey":
                    medical = medical.OrderBy(u => u.MedicalProfileKey);
                    break;
                case "MedicalProfileKey_desc":
                    medical = medical.OrderByDescending(u => u.MedicalProfileKey);
                    break;
                case "MedicalProfileName":
                    medical = medical.OrderBy(u => u.MedicalProfileTemplate.MedicalProfileTemplateName);
                    break;
                case "MedicalProfileName_desc":
                    medical = medical.OrderByDescending(u => u.MedicalProfileTemplate.MedicalProfileTemplateName);
                    break;
                default:
                    medical = medical.OrderBy(u => u.Patient.Email);
                    break;
            }
        }
    }
}
