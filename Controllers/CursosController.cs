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
    public class CursosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Cursos
        public IQueryable<Cursos> GetCursos()
        {
            return db.Cursos;
        }

        // GET: api/Cursos/5
        [ResponseType(typeof(Cursos))]
        public IHttpActionResult GetCursos(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return NotFound();
            }

            return Ok(cursos);
        }

        // PUT: api/Cursos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCursos(int id, Cursos cursos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursos.Id)
            {
                return BadRequest();
            }

            db.Entry(cursos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursosExists(id))
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

        // POST: api/Cursos
        [ResponseType(typeof(Cursos))]
        public IHttpActionResult PostCursos(Cursos cursos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cursos.Add(cursos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cursos.Id }, cursos);
        }

        // DELETE: api/Cursos/5
        [ResponseType(typeof(Cursos))]
        public IHttpActionResult DeleteCursos(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return NotFound();
            }

            db.Cursos.Remove(cursos);
            db.SaveChanges();

            return Ok(cursos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursosExists(int id)
        {
            return db.Cursos.Count(e => e.Id == id) > 0;
        }
    }
}