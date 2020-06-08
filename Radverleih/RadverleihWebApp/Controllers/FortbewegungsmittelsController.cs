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
    public class FortbewegungsmittelsController : Controller
    {
        private RadverleihModelContainer db = new RadverleihModelContainer();

        // GET: Fortbewegungsmittels
        public ActionResult Index()
        {
            var fortbewegungsmittels = db.Fortbewegungsmittels.Include(f => f.Kunde).Include(f => f.Modell).Include(f => f.Ablage);
            return View(fortbewegungsmittels.ToList());
        }

        // GET: Fortbewegungsmittels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortbewegungsmittel fortbewegungsmittel = db.Fortbewegungsmittels.Find(id);
            if (fortbewegungsmittel == null)
            {
                return HttpNotFound();
            }
            return View(fortbewegungsmittel);
        }

        // GET: Fortbewegungsmittels/Create
        public ActionResult Create()
        {
            ViewBag.KundeId = new[] {new SelectListItem()
            {Text = "-- kein Kunde --", Value = ""}}.Union(
                new SelectList(db.Kundes, "Id", "Name"));
            ViewBag.ModellId = new SelectList(db.Modells, "Id", "Bezeichnung");
            ViewBag.AblageId = new[] {new SelectListItem()
            {Text = "-- kein Ablageort --", Value = ""}}.Union(
                new SelectList(db.Ablages, "Id", "Bezeichnung"));
            return View();
        }

        // POST: Fortbewegungsmittels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nummer,Alter,Rückgabedatum,KundeId,ModellId,AblageId")] Fortbewegungsmittel fortbewegungsmittel)
        {
            if (ModelState.IsValid)
            {
                db.Fortbewegungsmittels.Add(fortbewegungsmittel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KundeId = new SelectList(db.Kundes, "Id", "Name", fortbewegungsmittel.KundeId);
            ViewBag.ModellId = new SelectList(db.Modells, "Id", "Bezeichnung", fortbewegungsmittel.ModellId);
            ViewBag.AblageId = new SelectList(db.Ablages, "Id", "Bezeichnung", fortbewegungsmittel.AblageId);
            return View(fortbewegungsmittel);
        }

        // GET: Fortbewegungsmittels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortbewegungsmittel fortbewegungsmittel = db.Fortbewegungsmittels.Find(id);
            if (fortbewegungsmittel == null)
            {
                return HttpNotFound();
            }
            ViewBag.KundeId = new SelectList(db.Kundes, "Id", "Name", fortbewegungsmittel.KundeId);
            ViewBag.ModellId = new SelectList(db.Modells, "Id", "Bezeichnung", fortbewegungsmittel.ModellId);
            ViewBag.AblageId = new SelectList(db.Ablages, "Id", "Bezeichnung", fortbewegungsmittel.AblageId);
            return View(fortbewegungsmittel);
        }

        // POST: Fortbewegungsmittels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nummer,Alter,Rückgabedatum,KundeId,ModellId,AblageId")] Fortbewegungsmittel fortbewegungsmittel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fortbewegungsmittel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KundeId = new SelectList(db.Kundes, "Id", "Name", fortbewegungsmittel.KundeId);
            ViewBag.ModellId = new SelectList(db.Modells, "Id", "Bezeichnung", fortbewegungsmittel.ModellId);
            ViewBag.AblageId = new SelectList(db.Ablages, "Id", "Bezeichnung", fortbewegungsmittel.AblageId);
            return View(fortbewegungsmittel);
        }

        // GET: Fortbewegungsmittels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortbewegungsmittel fortbewegungsmittel = db.Fortbewegungsmittels.Find(id);
            if (fortbewegungsmittel == null)
            {
                return HttpNotFound();
            }
            return View(fortbewegungsmittel);
        }

        // POST: Fortbewegungsmittels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fortbewegungsmittel fortbewegungsmittel = db.Fortbewegungsmittels.Find(id);
            db.Fortbewegungsmittels.Remove(fortbewegungsmittel);
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
