using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using APIFactura.Models;

namespace APIFactura
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext() : base("name = MyContextDB")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices{ get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails{ get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}