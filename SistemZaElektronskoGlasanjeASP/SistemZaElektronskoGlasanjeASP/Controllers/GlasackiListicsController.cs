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
    public class GlasackiListicsController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: GlasackiListics
        public ActionResult Index()
        {
            return View(db.GlasackiListic.ToList());
        }

        // GET: GlasackiListics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlasackiListic glasackiListic = db.GlasackiListic.Find(id);
            if (glasackiListic == null)
            {
                return HttpNotFound();
            }
            return View(glasackiListic);
        }

        // GET: GlasackiListics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlasackiListics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] GlasackiListic glasackiListic)
        {
            if (ModelState.IsValid)
            {
                db.GlasackiListic.Add(glasackiListic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glasackiListic);
        }

        // GET: GlasackiListics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlasackiListic glasackiListic = db.GlasackiListic.Find(id);
            if (glasackiListic == null)
            {
                return HttpNotFound();
            }
            return View(glasackiListic);
        }

        // POST: GlasackiListics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] GlasackiListic glasackiListic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glasackiListic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glasackiListic);
        }

        // GET: GlasackiListics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlasackiListic glasackiListic = db.GlasackiListic.Find(id);
            if (glasackiListic == null)
            {
                return HttpNotFound();
            }
            return View(glasackiListic);
        }

        // POST: GlasackiListics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlasackiListic glasackiListic = db.GlasackiListic.Find(id);
            db.GlasackiListic.Remove(glasackiListic);
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
