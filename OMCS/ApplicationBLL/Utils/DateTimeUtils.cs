using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using OMCS.DAL.Model;

namespace OMCS.BLL.Utils
{
    public class DateTimeUtils
    {
        public static int CalculateAge(DateTime birthdate)
        {
            int years = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.Month < birthdate.Month
            || (DateTime.Now.Month == birthdate.Month
                && DateTime.Now.Day < birthdate.Day))
                years--;
            return years;
        }
    }
}
