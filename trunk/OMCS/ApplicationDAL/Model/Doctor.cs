using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("Doctor")]
    public class Doctor : User
    {
        public Doctor()
        {
            Rating = 0;
            Votes = 0;
        }

        [ForeignKey("SpecialtyField")]
        public int SpecialtyFieldId { get; set; }
        public virtual SpecialtyField SpecialtyField { get; set; }
        public bool IsOnline { get; set; }

        [Display(Name = "Đánh giá")]
        public double Rating { get; set; }

        [Display(Name = "Lượt đánh giá")]
        public int Votes { get; set; }
    }
}
