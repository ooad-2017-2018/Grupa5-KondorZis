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
    public class GlasackoMjestoesController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: GlasackoMjestoes
        public ActionResult Index()
        {
            return View(db.GlasackoMjesto.ToList());
        }

        // GET: GlasackoMjestoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlasackoMjesto glasackoMjesto = db.GlasackoMjesto.Find(id);
            if (glasackoMjesto == null)
            {
                return HttpNotFound();
            }
            return View(glasackoMjesto);
        }

        // GET: GlasackoMjestoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlasackoMjestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LokacijaMjesta")] GlasackoMjesto glasackoMjesto)
        {
            if (ModelState.IsValid)
            {
                db.GlasackoMjesto.Add(glasackoMjesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glasackoMjesto);
        }

        // GET: GlasackoMjestoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlasackoMjesto glasackoMjesto = db.GlasackoMjesto.Find(id);
            if (glasackoMjesto == null)
            {
                return HttpNotFound();
            }
            return View(glasackoMjesto);
        }

        // POST: GlasackoMjestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LokacijaMjesta")] GlasackoMjesto glasackoMjesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glasackoMjesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glasackoMjesto);
        }

        // GET: GlasackoMjestoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlasackoMjesto glasackoMjesto = db.GlasackoMjesto.Find(id);
            if (glasackoMjesto == null)
            {
                return HttpNotFound();
            }
            return View(glasackoMjesto);
        }

        // POST: GlasackoMjestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GlasackoMjesto glasackoMjesto = db.GlasackoMjesto.Find(id);
            db.GlasackoMjesto.Remove(glasackoMjesto);
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
