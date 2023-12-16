using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doan.Models
{
    [Table("NHANVIEN")]
    public partial class Nhanvien
    {
        [Key]
        [Column("MaNV")]
        public int MaNv { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(20)]
        public string DienThoai { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string MatKhau { get; set; }
        [Column("TenCV")]
        [StringLength(50)]
        public string TenCv { get; set; }
    }
}
