using System.ComponentModel.DataAnnotations;

namespace bai_tap_buoi_6.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; } = "";
    }
}