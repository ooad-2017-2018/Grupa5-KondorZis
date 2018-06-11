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
    public class PSubjekatsController : ApiController
    {
        private BazaModel db = new BazaModel();

        // GET: api/PSubjekats
        public IQueryable<PSubjekat> GetPSubjekats()
        {
            return db.PSubjekats;
        }

        // GET: api/PSubjekats/5
        [ResponseType(typeof(PSubjekat))]
        public IHttpActionResult GetPSubjekat(string id)
        {
            PSubjekat pSubjekat = db.PSubjekats.Find(id);
            if (pSubjekat == null)
            {
                return NotFound();
            }

            return Ok(pSubjekat);
        }

        // PUT: api/PSubjekats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPSubjekat(string id, PSubjekat pSubjekat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSubjekat.ImeSubjekta)
            {
                return BadRequest();
            }

            db.Entry(pSubjekat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSubjekatExists(id))
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

        // POST: api/PSubjekats
        [ResponseType(typeof(PSubjekat))]
        public IHttpActionResult PostPSubjekat(PSubjekat pSubjekat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PSubjekats.Add(pSubjekat);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PSubjekatExists(pSubjekat.ImeSubjekta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pSubjekat.ImeSubjekta }, pSubjekat);
        }

        // DELETE: api/PSubjekats/5
        [ResponseType(typeof(PSubjekat))]
        public IHttpActionResult DeletePSubjekat(string id)
        {
            PSubjekat pSubjekat = db.PSubjekats.Find(id);
            if (pSubjekat == null)
            {
                return NotFound();
            }

            db.PSubjekats.Remove(pSubjekat);
            db.SaveChanges();

            return Ok(pSubjekat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PSubjekatExists(string id)
        {
            return db.PSubjekats.Count(e => e.ImeSubjekta == id) > 0;
        }
    }
}