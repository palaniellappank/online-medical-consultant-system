using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("PersonalHealthRecord")]
    public class PersonalHealthRecord
    {
        [Key, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        //Apperance
        [Description("Chiều Cao")]
	    public double Height { get; set; }

        [Description("Cân Nặng")]
        public double Weight { get; set; }

        [Description("Màu Mắt")]
	    public string EyeColor { get; set; }

        [Description("Màu Tóc")]
	    public string HairColor { get; set; }

        [Description("Nhóm Máu")]
        public string BloodType { get; set; }

        //Life Style Part

        [Display(Name = "Lượng đồ uống có cồn (lít) hằng tuần")]
	    public double AlcoholPerWeek { get; set; }
        [Display(Name = "Số năm uống")]
	    public int AlcoholNumOfYear { get; set; }
        public bool IsBeer { get; set; }

        [Display(Name = "Lượng thuốc hút (gói) hằng tuần")]
	    public double SmokePackPerWeek { get; set; }
        [Display(Name = "Số năm hút")]
	    public int SmokeNumOfYear { get; set; }

        [Display(Name = "Tên loại thể thao")]
	    public string SportName { get; set; }
        //Hours per week
        [Display(Name = "Thời lượng tham gia (giờ) hằng tuần")]
	    public int SportPerWeek { get; set; }

        [Display(Name = "Tham gia khác (Yoga, Thiền định,...)")]
	    public string ExerciseType { get; set; }
        [Display(Name = "Thời lượng tham gia (giờ) hằng tuần")]
        public int ExercisePerWeek { get; set; }
    }
}
