﻿using System;
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
    public class AgentsController : ApiController
    {
        private CosmaticDbContext db = new CosmaticDbContext();

        // GET: api/Agents
        public IQueryable<Agent> GetAgents()
        {
            return db.Agents;
        }

        // GET: api/Agents/5
        [ResponseType(typeof(Agent))]
        public IHttpActionResult GetAgent(int id)
        {
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }

            return Ok(agent);
        }

        // PUT: api/Agents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgent(int id, Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agent.Id)
            {
                return BadRequest();
            }

            db.Entry(agent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(id))
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

        // POST: api/Agents
        [ResponseType(typeof(Agent))]
        public IHttpActionResult PostAgent(Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agents.Add(agent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agent.Id }, agent);
        }

        // DELETE: api/Agents/5
        [ResponseType(typeof(Agent))]
        public IHttpActionResult DeleteAgent(int id)
        {
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }

            db.Agents.Remove(agent);
            db.SaveChanges();

            return Ok(agent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgentExists(int id)
        {
            return db.Agents.Count(e => e.Id == id) > 0;
        }
    }
}