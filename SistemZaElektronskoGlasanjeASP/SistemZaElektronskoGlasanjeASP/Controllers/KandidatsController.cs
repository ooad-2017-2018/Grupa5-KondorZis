using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemZaElektronskoGlasanjeASP.Models;

namespace SistemZaElektronskoGlasanjeASP.Controllers
{
    public class KandidatsController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: Kandidats
        public ActionResult Index()
        {
            return View(db.Kandidat.ToList());
        }

        // GET: Kandidats/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kandidat kandidat = db.Kandidat.Find(id);
            if (kandidat == null)
            {
                return HttpNotFound();
            }
            return View(kandidat);
        }

        // GET: Kandidats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kandidats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JMBG,Ime,Prezime,Mjesto_stanovanja,N")] Kandidat kandidat)
        {
            if (ModelState.IsValid)
            {
                db.Kandidat.Add(kandidat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kandidat);
        }

        // GET: Kandidats/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kandidat kandidat = db.Kandidat.Find(id);
            if (kandidat == null)
            {
                return HttpNotFound();
            }
            return View(kandidat);
        }

        // POST: Kandidats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JMBG,Ime,Prezime,Mjesto_stanovanja,N")] Kandidat kandidat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kandidat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kandidat);
        }

        // GET: Kandidats/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kandidat kandidat = db.Kandidat.Find(id);
            if (kandidat == null)
            {
                return HttpNotFound();
            }
            return View(kandidat);
        }

        // POST: Kandidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Kandidat kandidat = db.Kandidat.Find(id);
            db.Kandidat.Remove(kandidat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
