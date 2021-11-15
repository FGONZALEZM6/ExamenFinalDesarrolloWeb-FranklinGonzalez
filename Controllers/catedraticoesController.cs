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
using FinalFranklinGonzalez.Models;

namespace FinalFranklinGonzalez.Controllers
{
    public class catedraticoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/catedraticoes
        public IQueryable<catedratico> Getcatedratico()
        {
            return db.catedratico;
        }

        // GET: api/catedraticoes/5
        [ResponseType(typeof(catedratico))]
        public IHttpActionResult Getcatedratico(int id)
        {
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return Ok(catedratico);
        }

        // PUT: api/catedraticoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcatedratico(int id, catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catedratico.Id)
            {
                return BadRequest();
            }

            db.Entry(catedratico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!catedraticoExists(id))
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

        // POST: api/catedraticoes
        [ResponseType(typeof(catedratico))]
        public IHttpActionResult Postcatedratico(catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.catedratico.Add(catedratico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = catedratico.Id }, catedratico);
        }

        // DELETE: api/catedraticoes/5
        [ResponseType(typeof(catedratico))]
        public IHttpActionResult Deletecatedratico(int id)
        {
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            db.catedratico.Remove(catedratico);
            db.SaveChanges();

            return Ok(catedratico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool catedraticoExists(int id)
        {
            return db.catedratico.Count(e => e.Id == id) > 0;
        }
    }
}