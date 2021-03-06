﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{

    [Table("Allergy")]
    public class Allergy
    {   
        [Key]
        public int AllergyId { get; set; }

        [ForeignKey("MedicalProfile")]
        public int MedicalProfileId { get; set; }
        public virtual MedicalProfile MedicalProfile { get; set; }
      
        [ForeignKey("AllergyType")]
        public int AllergyTypeId { get; set; }
        public virtual AllergyType AllergyType { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày bị dị ứng gần nhất")]
        public DateTime DateLastOccurred { get; set; }

        [Display(Name = "Phản ứng")]
        public string Reaction { get; set; }
        public string Note { get; set; }
    }
}
