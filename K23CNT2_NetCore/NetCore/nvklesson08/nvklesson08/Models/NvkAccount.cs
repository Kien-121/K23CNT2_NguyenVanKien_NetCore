using System;
using System.ComponentModel.DataAnnotations;
namespace nvklesson08.Models
{
    public class NvkAccount
    {
        [Key]
        public int NvkId { get; set; }
        [
            Display(Name = "Họ và tên"),
            Required(ErrorMessage = "Họ không được để trống"),
            MinLength(6, ErrorMessage = "Họ phải có ít nhất 6 ký tự"),
            MaxLength(20, ErrorMessage = "Họ không được quá 20 ký tự"),
            ]
        public string NvkFullName { get; set; }
        [Display(Name = "Địa chỉ Email ")]
        [ Required(ErrorMessage = "Địa chỉ Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        public string NvkEmail { get; set; }
        [
            Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [
            RegularExpression(@"^(\+84|0)[0-9]{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [ Required(ErrorMessage = "Số điện thoại không được để trống")]
            
        public string NvkPhone { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(100, ErrorMessage = "Địa chỉ không được quá 100 ký tự")]

        public string NvkAddress { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string NvkAvatar { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime NvkBirthday { get; set; }
        [Display(Name = "Giới tính")]
        public string NvkGender { get; set; }
        [Display(Name = "Mật khẩu")]
        public string NvkPassword { get; set; }
        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "Link Facebook không hợp lệ")]
        public string NvkFacebook { get; set; }
    }
}

