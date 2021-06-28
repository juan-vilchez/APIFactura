using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceAddress { get; set; }
        public int RucIssuer { get; set; }
        public int RucReceiver { get; set; }
        public DateTime OrderDate { get; set; }
        public string State { get; set; }
        public decimal Total { get; set; }
        public decimal Igv { get; set; }

    }
}