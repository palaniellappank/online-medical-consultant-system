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
    public class AdminCommentBusiness : BaseBusiness
    {
        //Check the Sort Order to sort with corresponding column
        public void CheckSortOrder(string sortOrder, ref IEnumerable<Comment> comment)
        {
            switch (sortOrder)
            {                              
                case "Date_desc":
                    comment = comment.OrderByDescending(u => u.PostedDate);
                    break;                
                case "PatientName":
                    comment = comment.OrderBy(u => u.Patient.FullName);
                    break;
                case "PatientName_desc":
                    comment = comment.OrderByDescending(u => u.Patient.FullName);
                    break;
                case "DoctorName":
                    comment = comment.OrderBy(u => u.Doctor.FullName);
                    break;
                case "DoctorName_desc":
                    comment = comment.OrderByDescending(u => u.Doctor.FullName);
                    break;
                case "Content":
                    comment = comment.OrderBy(u => u.Content);
                    break;
                case "Content_desc":
                    comment = comment.OrderByDescending(u => u.Content);
                    break;
                default:
                    comment = comment.OrderBy(u => u.PostedDate);
                    break;
            }
        }

        //Check Search String to search by UserName/FullName
        public void SearchByString(string searchString, ref IEnumerable<Comment> comment)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                comment = comment.Where(u => (!String.IsNullOrWhiteSpace(u.Patient.FullName) && (u.Patient.FullName.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.Doctor.FullName) && (u.Doctor.FullName.ToUpper().Contains(searchString.ToUpper())))
                                    || (!String.IsNullOrWhiteSpace(u.Content) && (u.Content.ToUpper().Contains(searchString.ToUpper()))));
            }
        }  
    }
}
