using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Dni { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}