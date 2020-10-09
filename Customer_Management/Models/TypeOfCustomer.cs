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

        public string Type { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}