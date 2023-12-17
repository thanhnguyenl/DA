using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("DANHMUC")]
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Mathang = new HashSet<Mathang>();
        }

        [Key]
        [Column("MaDM")]
        public int MaDm { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Tên danh mục")]
        public string Ten { get; set; }

        [InverseProperty("MaDmNavigation")]
        public virtual ICollection<Mathang> Mathang { get; set; }
    }
}
