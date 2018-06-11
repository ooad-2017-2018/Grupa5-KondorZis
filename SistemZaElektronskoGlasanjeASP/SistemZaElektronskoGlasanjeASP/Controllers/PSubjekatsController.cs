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
    public class PSubjekatsController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: PSubjekats
        public ActionResult Index()
        {
            return View(db.PSubjekat.ToList());
        }

        // GET: PSubjekats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSubjekat pSubjekat = db.PSubjekat.Find(id);
            if (pSubjekat == null)
            {
                return HttpNotFound();
            }
            return View(pSubjekat);
        }

        // GET: PSubjekats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PSubjekats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImeSubjekta")] PSubjekat pSubjekat)
        {
            if (ModelState.IsValid)
            {
                db.PSubjekat.Add(pSubjekat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pSubjekat);
        }

        // GET: PSubjekats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSubjekat pSubjekat = db.PSubjekat.Find(id);
            if (pSubjekat == null)
            {
                return HttpNotFound();
            }
            return View(pSubjekat);
        }

        // POST: PSubjekats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImeSubjekta")] PSubjekat pSubjekat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSubjekat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pSubjekat);
        }

        // GET: PSubjekats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSubjekat pSubjekat = db.PSubjekat.Find(id);
            if (pSubjekat == null)
            {
                return HttpNotFound();
            }
            return View(pSubjekat);
        }

        // POST: PSubjekats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PSubjekat pSubjekat = db.PSubjekat.Find(id);
            db.PSubjekat.Remove(pSubjekat);
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
