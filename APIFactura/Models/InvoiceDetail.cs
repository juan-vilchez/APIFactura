using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}