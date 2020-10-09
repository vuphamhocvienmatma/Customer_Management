using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Customer_Management.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập mã khách hàng")]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập tên khách hàng")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày sinh khách hàng")]
        [Column(TypeName = "DATETIME")]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Số điện thoại")]
        public int PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Giới tính")]
        [Column(TypeName = "NVARCHAR")]
        public string GioiTinh { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(500)]
        public string PictureId { get; set; }

        [Display(Name = "Loại khách hàng")]
        public int TypeofCustomerId { get; set; }

        [ForeignKey("TypeofCustomerId")]
        public virtual TypeOfCustomer TypeOfCustomer { get; set; }
    }
}