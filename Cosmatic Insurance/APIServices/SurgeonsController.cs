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
using Cosmatic_Insurance.Data;
using Cosmatic_Insurance.Models;

namespace Cosmatic_Insurance.APIServices
{
    public class SurgeonsController : ApiController
    {
        private CosmaticDbContext db = new CosmaticDbContext();

        // GET: api/Surgeons
        public IQueryable<Surgeon> GetSurgeons()
        {
            return db.Surgeons;
        }

        // GET: api/Surgeons/5
        [ResponseType(typeof(Surgeon))]
        public IHttpActionResult GetSurgeon(int id)
        {
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return NotFound();
            }

            return Ok(surgeon);
        }

        // PUT: api/Surgeons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSurgeon(int id, Surgeon surgeon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surgeon.Id)
            {
                return BadRequest();
            }

            db.Entry(surgeon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurgeonExists(id))
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

        // POST: api/Surgeons
        [ResponseType(typeof(Surgeon))]
        public IHttpActionResult PostSurgeon(Surgeon surgeon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Surgeons.Add(surgeon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = surgeon.Id }, surgeon);
        }

        // DELETE: api/Surgeons/5
        [ResponseType(typeof(Surgeon))]
        public IHttpActionResult DeleteSurgeon(int id)
        {
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return NotFound();
            }

            db.Surgeons.Remove(surgeon);
            db.SaveChanges();

            return Ok(surgeon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurgeonExists(int id)
        {
            return db.Surgeons.Count(e => e.Id == id) > 0;
        }
    }
}