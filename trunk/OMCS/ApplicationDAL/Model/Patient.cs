using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("Patient")]
    public class Patient : User
    {
        [Display(Name = "Dân tộc")]
        public string Ethnicity { get; set; }

        [Display(Name = "Quốc tịch")]
        public string Nationality { get; set; }

        [Display(Name = "Công việc")]
        public string Job { get; set; }

        [Display(Name = "Nơi làm việc")]
	    public string WhereToWork { get; set; }

        [Display(Name = "Người liên lạc")]
        public string ContactPerson { get; set; }

        [Display(Name = "Địa chỉ người liên lạc")]
        public string ContactPersonAddress { get; set; }

        [Display(Name = "Mã số thẻ bảo hiểm y tế")]
        public string HealthInsuranceId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày cấp")]
        public DateTime? HealthInsuranceIssued { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày hết hạn")]
        public DateTime? HealthInsuranceDateExpired { get; set; }

        public Patient() {}
        public Patient(User user)
        {
            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                if (!prop.Name.Equals("FullName"))
                {
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(user, null), null);
                }
            }
        }
    }
}
