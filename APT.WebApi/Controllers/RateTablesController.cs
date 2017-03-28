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
using APT.BusinessObjects.Models;

namespace APT.WebApi.Controllers
{
    public class RateTablesController : ApiController
    {
        private AllPointsTransportEntities db = new AllPointsTransportEntities();

        // GET: api/RateTables
        public IQueryable<RateTable> GetRateTables()
        {
            return db.RateTables;
        }

        // GET: api/RateTables/5
        [ResponseType(typeof(RateTable))]
        public IHttpActionResult GetRateTable(int id)
        {
            RateTable rateTable = db.RateTables.Find(id);
            if (rateTable == null)
            {
                return NotFound();
            }

            return Ok(rateTable);
        }

        // PUT: api/RateTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRateTable(int id, RateTable rateTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rateTable.Id)
            {
                return BadRequest();
            }

            db.Entry(rateTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateTableExists(id))
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

        // POST: api/RateTables
        [ResponseType(typeof(RateTable))]
        public IHttpActionResult PostRateTable(RateTable rateTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RateTables.Add(rateTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rateTable.Id }, rateTable);
        }

        // DELETE: api/RateTables/5
        [ResponseType(typeof(RateTable))]
        public IHttpActionResult DeleteRateTable(int id)
        {
            RateTable rateTable = db.RateTables.Find(id);
            if (rateTable == null)
            {
                return NotFound();
            }

            db.RateTables.Remove(rateTable);
            db.SaveChanges();

            return Ok(rateTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RateTableExists(int id)
        {
            return db.RateTables.Count(e => e.Id == id) > 0;
        }
    }
}