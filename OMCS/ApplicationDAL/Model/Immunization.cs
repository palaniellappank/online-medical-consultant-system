﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("Immunization")]
    public class Immunization
    {
        [Key]
        public int ImmunizationId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public string Name { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public int BoosterTime { get; set; }
    }
}
