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
    public class UtrkasController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: Utrkas
        public ActionResult Index()
        {
            return View(db.Utrka.ToList());
        }

        // GET: Utrkas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utrka utrka = db.Utrka.Find(id);
            if (utrka == null)
            {
                return HttpNotFound();
            }
            return View(utrka);
        }

        // GET: Utrkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utrkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Naziv")] Utrka utrka)
        {
            if (ModelState.IsValid)
            {
                db.Utrka.Add(utrka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utrka);
        }

        // GET: Utrkas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utrka utrka = db.Utrka.Find(id);
            if (utrka == null)
            {
                return HttpNotFound();
            }
            return View(utrka);
        }

        // POST: Utrkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Naziv")] Utrka utrka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utrka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utrka);
        }

        // GET: Utrkas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utrka utrka = db.Utrka.Find(id);
            if (utrka == null)
            {
                return HttpNotFound();
            }
            return View(utrka);
        }

        // POST: Utrkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Utrka utrka = db.Utrka.Find(id);
            db.Utrka.Remove(utrka);
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
