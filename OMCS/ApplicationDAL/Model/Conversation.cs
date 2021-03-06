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
    [Table("Conversation")]
    public class Conversation
    {
        [Key]
        public int ConversationId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public string LatestContentFromPatient { get; set; }
        public string LatestContentFromDoctor { get; set; }
        [DataType(DataType.Date)]
        public DateTime LatestTimeFromDoctor { get; set; }
        [DataType(DataType.Date)]
        public DateTime LatestTimeFromPatient { get; set; }
        public bool IsDoctorRead { get; set; }
        public bool IsPatientRead { get; set; }
    }
}
