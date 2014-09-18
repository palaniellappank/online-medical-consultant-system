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
    [Table("CustomSnippetValue")]
    public class CustomSnippetValue
    {
        [Key]
        public int CustomSnippetValueId { get; set; }

        [ForeignKey("CustomSnippet")]
        public int CustomSnippetId { get; set; }
        public virtual CustomSnippet CustomSnippet { get; set; }

        [ForeignKey("MedicalProfile")]
        public int MedicalProfileId { get; set; }
        public virtual MedicalProfile MedicalProfile { get; set; }

	    public string Value { get; set; }
    }
}
