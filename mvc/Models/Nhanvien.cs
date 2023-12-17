using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("NHANVIEN")]
    public partial class Nhanvien
    {
        [Key]
        [Column("MaNV")]
        public int MaNv { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Tên nhân viên")]
        public string Ten { get; set; }
        [Column("MaCV")]
        [Display(Name = "Chức vụ")]
        public int MaCv { get; set; }
        [StringLength(20)]
        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
        [Display(Name = "Tên chức vụ")]
        [ForeignKey(nameof(MaCv))]
        [InverseProperty(nameof(Chucvu.Nhanvien))]
        public virtual Chucvu MaCvNavigation { get; set; }
    }
}
