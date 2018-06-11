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
using SistemZaElektronskoGlasanjeAPI.Models;

namespace SistemZaElektronskoGlasanjeAPI.Controllers
{
    public class KandidatsController : ApiController
    {
        private BazaModel db = new BazaModel();

        // GET: api/Kandidats
        public IQueryable<Kandidat> GetKandidats()
        {
            return db.Kandidats;
        }

        // GET: api/Kandidats/5
        [ResponseType(typeof(Kandidat))]
        public IHttpActionResult GetKandidat(long id)
        {
            Kandidat kandidat = db.Kandidats.Find(id);
            if (kandidat == null)
            {
                return NotFound();
            }

            return Ok(kandidat);
        }

        // PUT: api/Kandidats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKandidat(long id, Kandidat kandidat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kandidat.JMBG)
            {
                return BadRequest();
            }

            db.Entry(kandidat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KandidatExists(id))
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

        // POST: api/Kandidats
        [ResponseType(typeof(Kandidat))]
        public IHttpActionResult PostKandidat(Kandidat kandidat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kandidats.Add(kandidat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kandidat.JMBG }, kandidat);
        }

        // DELETE: api/Kandidats/5
        [ResponseType(typeof(Kandidat))]
        public IHttpActionResult DeleteKandidat(long id)
        {
            Kandidat kandidat = db.Kandidats.Find(id);
            if (kandidat == null)
            {
                return NotFound();
            }

            db.Kandidats.Remove(kandidat);
            db.SaveChanges();

            return Ok(kandidat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KandidatExists(long id)
        {
            return db.Kandidats.Count(e => e.JMBG == id) > 0;
        }
    }
}