using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OMCS.DAL.Model
{
    [Table("User")]
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*Bạn cần nhập thông tin này")]
        [StringLength(50, ErrorMessage = "*Độ dài không được quá 50 ký tự")]
        [Remote("CheckUserNameExist", "AdminUser", HttpMethod = "POST", ErrorMessage = "*Tên tài khoản đã tồn tại")]
        [Display(Name = "Tên đăng nhập")]
        public String Username { get; set; }

        [Required(ErrorMessage = "*Bạn cần nhập thông tin này")]
        [StringLength(50, ErrorMessage = "Độ dài không được quá 50 ký tự")]
        [EmailAddress(ErrorMessage = "*Địa chỉ Email không tồn tại")]
        [Remote("CheckEmailExist", "AdminUser", HttpMethod = "POST", ErrorMessage = "*Email đã tồn tại")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "*Bạn cần nhập thông tin này")]
        [Display(Name = "Mật khẩu")]
        public String Password { get; set; }

        [StringLength(50, ErrorMessage = "*Độ dài không được quá 50 ký tự")]
        [Display(Name = "Tên")]
        public String FirstName { get; set; }

        [StringLength(50, ErrorMessage = "*Độ dài không được quá 50 ký tự")]
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

        [Display(Name = "Hình đại diện")]
        public String ProfilePicture { get; set; }

        [Display(Name = "Giới tính")]
        [StringLength(1)]
        public String Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày sinh")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Số điện thoại")]
        public String Phone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        public String PrimaryAddress { get; set; }

        [Display(Name = "Địa chỉ tạm trú")]
        public String SecondaryAddress { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
