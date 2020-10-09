using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Customer_Management.Models
{
    public class Customer_Management_Context : DbContext
    {
        public Customer_Management_Context() : base("Customer_Management_Connect")
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<TypeOfCustomer> typeofcustomer { get; set; }
    }
}