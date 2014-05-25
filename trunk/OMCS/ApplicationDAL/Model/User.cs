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
        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public String Username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên")]
        public String FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ")]
        public String LastName { get; set; }

        [Display(Name = "Tên đầy đủ")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public bool IsActive { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Tạo")]
        public DateTime CreatedDate { get; set; }


        public String ProfilePicture { get; set; }

        [Display(Name = "Giới tính")]
        public String Gender { get; set; }

        [Display(Name = "Ngày sinh")]
        public String Birthday { get; set; }

        [Display(Name = "Số điện thoại")]
        public String Phone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        public String PrimaryAddress { get; set; }

        [Display(Name = "Địa chỉ tạm trú")]
        public String TemporaryAddress { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
