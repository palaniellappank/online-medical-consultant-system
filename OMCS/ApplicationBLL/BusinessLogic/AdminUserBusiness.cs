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
    public class AdminUserBusiness: BaseBusiness
    {
        //Check the Sort Order to sort with corresponding column
        public void CheckSortOrder(string sortOrder,ref IEnumerable<User> users)
        {
            switch (sortOrder)
            {
                case "User_desc":
                    users = users.OrderByDescending(u => u.Username);
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
                default:
                    users = users.OrderBy(u => u.Username);
                    break;
            }
        }
        
        //Check Search String to search by UserName/FullName
        public void SearchByString(string searchString, ref IEnumerable<User> users)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Username.ToUpper().Contains(searchString.ToUpper())
                                    || u.FullName.ToUpper().Contains(searchString.ToUpper()));
            }
        }
    }
}
