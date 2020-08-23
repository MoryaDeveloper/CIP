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
    public class PoliciesController : ApiController
    {
        private CosmaticDbContext db = new CosmaticDbContext();

        // GET: api/Policies
        public IQueryable<Policy> GetPolicys()
        {
            return db.Policys;
        }

        // GET: api/Policies/5
        [ResponseType(typeof(Policy))]
        public IHttpActionResult GetPolicy(int id)
        {
            Policy policy = db.Policys.Find(id);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        // PUT: api/Policies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPolicy(int id, Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policy.Id)
            {
                return BadRequest();
            }

            db.Entry(policy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        // POST: api/Policies
        [ResponseType(typeof(Policy))]
        public IHttpActionResult PostPolicy(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Policys.Add(policy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = policy.Id }, policy);
        }

        // DELETE: api/Policies/5
        [ResponseType(typeof(Policy))]
        public IHttpActionResult DeletePolicy(int id)
        {
            Policy policy = db.Policys.Find(id);
            if (policy == null)
            {
                return NotFound();
            }

            db.Policys.Remove(policy);
            db.SaveChanges();

            return Ok(policy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolicyExists(int id)
        {
            return db.Policys.Count(e => e.Id == id) > 0;
        }
    }
}