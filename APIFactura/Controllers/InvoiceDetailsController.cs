using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIFactura;
using APIFactura.Models;

namespace APIFactura.Controllers
{
    public class InvoiceDetailsController : ApiController
    {
        private InvoiceContext db = new InvoiceContext();

        // GET: api/InvoiceDetails
        //Se cambio  a los demás IQuerable por List
        public IQueryable<InvoiceDetail> GetInvoiceDetails()
        {
            return db.InvoiceDetails;
        }

        // GET: api/InvoiceDetails/5
        [ResponseType(typeof(InvoiceDetail))]
        public IHttpActionResult GetInvoiceDetail(int id)
        {
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return Ok(invoiceDetail);
        }

        // PUT: api/InvoiceDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvoiceDetail(int id, InvoiceDetail invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoiceDetail.InvoiceDetailId)
            {
                return BadRequest();
            }

            db.Entry(invoiceDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InvoiceDetails
        [ResponseType(typeof(InvoiceDetail))]
        public IHttpActionResult PostInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvoiceDetails.Add(invoiceDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = invoiceDetail.InvoiceDetailId }, invoiceDetail);
        }

        // DELETE: api/InvoiceDetails/5
        [ResponseType(typeof(InvoiceDetail))]
        public IHttpActionResult DeleteInvoiceDetail(int id)
        {
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            db.InvoiceDetails.Remove(invoiceDetail);
            db.SaveChanges();

            return Ok(invoiceDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoiceDetailExists(int id)
        {
            return db.InvoiceDetails.Count(e => e.InvoiceDetailId == id) > 0;
        }
    }
}