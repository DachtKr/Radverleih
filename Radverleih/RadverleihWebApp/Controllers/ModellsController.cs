using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RadverleihLib;

namespace RadverleihWebApp.Controllers
{
    public class ModellsController : Controller
    {
        private RadverleihModelContainer db = new RadverleihModelContainer();

        // GET: Modells
        public ActionResult Index()
        {
            return View(db.Modells.ToList());
        }

        // GET: Modells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modell modell = db.Modells.Find(id);
            if (modell == null)
            {
                return HttpNotFound();
            }
            return View(modell);
        }

        // GET: Modells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bezeichnung,Beschreibung,Preis,Größe")] Modell modell)
        {
            if (ModelState.IsValid)
            {
                db.Modells.Add(modell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modell);
        }

        // GET: Modells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modell modell = db.Modells.Find(id);
            if (modell == null)
            {
                return HttpNotFound();
            }
            return View(modell);
        }

        // POST: Modells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bezeichnung,Beschreibung,Preis,Größe")] Modell modell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modell);
        }

        // GET: Modells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modell modell = db.Modells.Find(id);
            if (modell == null)
            {
                return HttpNotFound();
            }
            return View(modell);
        }

        // POST: Modells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modell modell = db.Modells.Find(id);
            db.Modells.Remove(modell);
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
