using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Description { get; set; }


        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }


        [ForeignKey("Invoice")]
        public int IdInvoice { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}