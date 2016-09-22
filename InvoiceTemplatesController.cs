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
using subscriptions.Models;

namespace subscriptions.Controllers
{
    public class InvoiceTemplatesController : ApiController
    {
        private subscriptionsContext db = new subscriptionsContext();

        // GET: api/InvoiceTemplates
        public IQueryable<InvoiceTemplate> GetInvoiceTemplates()
        {
            return db.InvoiceTemplates;
        }

        // GET: api/InvoiceTemplates/5
        [ResponseType(typeof(InvoiceTemplate))]
        public IHttpActionResult GetInvoiceTemplate(int id)
        {
            InvoiceTemplate invoiceTemplate = db.InvoiceTemplates.Find(id);
            if (invoiceTemplate == null)
            {
                return NotFound();
            }

            return Ok(invoiceTemplate);
        }

        // PUT: api/InvoiceTemplates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvoiceTemplate(int id, InvoiceTemplate invoiceTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoiceTemplate.MerchantId)
            {
                return BadRequest();
            }

            db.Entry(invoiceTemplate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTemplateExists(id))
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

        // POST: api/InvoiceTemplates
        [ResponseType(typeof(InvoiceTemplate))]
        public IHttpActionResult PostInvoiceTemplate(InvoiceTemplate invoiceTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvoiceTemplates.Add(invoiceTemplate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = invoiceTemplate.MerchantId }, invoiceTemplate);
        }

        // DELETE: api/InvoiceTemplates/5
        [ResponseType(typeof(InvoiceTemplate))]
        public IHttpActionResult DeleteInvoiceTemplate(int id)
        {
            InvoiceTemplate invoiceTemplate = db.InvoiceTemplates.Find(id);
            if (invoiceTemplate == null)
            {
                return NotFound();
            }

            db.InvoiceTemplates.Remove(invoiceTemplate);
            db.SaveChanges();

            return Ok(invoiceTemplate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoiceTemplateExists(int id)
        {
            return db.InvoiceTemplates.Count(e => e.MerchantId == id) > 0;
        }
    }
}