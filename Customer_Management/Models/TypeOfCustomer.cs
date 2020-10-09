using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Customer_Management.Models
{
    [Table("TypeOfCustomer")]
    public class TypeOfCustomer
    {
        [Key]
        public int IdOftype { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string PictureId { get; set; }

        [Display(Name = "Loại khách hàng")]
        public string Type { get; set; }

        [Display(Name = "Chi tiết")]
        public string Details { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}