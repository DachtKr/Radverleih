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
    public class AblagesController : Controller
    {
        private RadverleihModelContainer db = new RadverleihModelContainer();

        // GET: Ablages
        public ActionResult Index()
        {
            return View(db.Ablages.ToList());
        }

        // GET: Ablages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ablage ablage = db.Ablages.Find(id);
            if (ablage == null)
            {
                return HttpNotFound();
            }
            return View(ablage);
        }

        // GET: Ablages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ablages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bezeichnung")] Ablage ablage)
        {
            if (ModelState.IsValid)
            {
                db.Ablages.Add(ablage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ablage);
        }

        // GET: Ablages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ablage ablage = db.Ablages.Find(id);
            if (ablage == null)
            {
                return HttpNotFound();
            }
            return View(ablage);
        }

        // POST: Ablages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bezeichnung")] Ablage ablage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ablage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ablage);
        }

        // GET: Ablages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ablage ablage = db.Ablages.Find(id);
            if (ablage == null)
            {
                return HttpNotFound();
            }
            return View(ablage);
        }

        // POST: Ablages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ablage ablage = db.Ablages.Find(id);
            db.Ablages.Remove(ablage);
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
