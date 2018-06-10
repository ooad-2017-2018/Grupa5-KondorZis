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
    public class GlasacsController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: Glasacs
        public ActionResult Index()
        {
            return View(db.Glasac.ToList());
        }

        // GET: Glasacs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glasac glasac = db.Glasac.Find(id);
            if (glasac == null)
            {
                return HttpNotFound();
            }
            return View(glasac);
        }

        // GET: Glasacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glasacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Jmbg,Ime,Prezime,BrLicneKarte,MjestoStanovanja")] Glasac glasac)
        {
            if (ModelState.IsValid)
            {
                db.Glasac.Add(glasac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glasac);
        }

        // GET: Glasacs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glasac glasac = db.Glasac.Find(id);
            if (glasac == null)
            {
                return HttpNotFound();
            }
            return View(glasac);
        }

        // POST: Glasacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Jmbg,Ime,Prezime,BrLicneKarte,MjestoStanovanja")] Glasac glasac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glasac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glasac);
        }

        // GET: Glasacs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glasac glasac = db.Glasac.Find(id);
            if (glasac == null)
            {
                return HttpNotFound();
            }
            return View(glasac);
        }

        // POST: Glasacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Glasac glasac = db.Glasac.Find(id);
            db.Glasac.Remove(glasac);
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
