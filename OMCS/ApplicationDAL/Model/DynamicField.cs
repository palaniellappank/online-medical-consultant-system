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
    public enum FieldType
    {
        [Description("Text")]
        Text = 0,

        [Description("TextArea")]
        TextArea = 1,

        [Description("RadioButton")]
        RadioButton = 2,

        [Description("DropDown")]
        DropDown = 4
    }
    [Table("DynamicField")]
    public class DynamicField
    {
        [Key]
        public int DynamicFieldId { get; set; }

        [ForeignKey("MedicalProfileTemplate")]
        public int MedicalProfileTemplateId { get; set; }
        public virtual MedicalProfileTemplate MedicalProfileTemplate { get; set; }
        
        public int Position { get; set; }
        public FieldType FieldType { get; set; }
	    public string Name { get; set; }
        public DynamicField Parent { get; set; }
    }
}
