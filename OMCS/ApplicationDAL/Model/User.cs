using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }

        public Boolean IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public String ProfilePicture { get; set; }
        public String Gender { get; set; }
        public String Birthday { get; set; }
        public String Phone { get; set; }
        public String PrimaryAddress { get; set; }
        public String TemporaryAddress { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
