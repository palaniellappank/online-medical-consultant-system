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
	    public string Height { get; set; }

        [Description("Cân Nặng")]
	    public string Weight { get; set; }

        [Description("Màu Mắt")]
	    public string EyeColor { get; set; }

        [Description("Màu Tóc")]
	    public string HairColor { get; set; }

        [Description("Nhóm Máu")]
        public string BloodType { get; set; }

        //Life Style Part
	    public string AlcoholPerWeek { get; set; }
	    public string AlcoholNumOfYear { get; set; }
    
	    public string SmokePackPerDay { get; set; }
	    public string SmokeNumOfYear { get; set; }

	    public string SportName { get; set; }
	    public string SportPerWeek { get; set; }

	    public string ExerciseType { get; set; }
        public string ExerciseDayPerWeek { get; set; }
    }
}
