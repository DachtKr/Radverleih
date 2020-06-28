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
    public class AusleihenController : Controller
    {
        private RadverleihModelContainer db = new RadverleihModelContainer();
       
    // GET: Ausleihen/Details/5
    public ActionResult Ausleihen (int? kundeId, int? fzgId)
        {
            if (kundeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kundes.Find(kundeId);//ID des ausgewählten Kunden merken

            if (kunde == null)
            {
                return HttpNotFound();
            }

            if (fzgId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortbewegungsmittel fortbewegungsmittel = db.Fortbewegungsmittels.Find(fzgId);
                                               //ID des ausgewählten Fortbewegungsmittels merken 
            if (fortbewegungsmittel == null)
            {
                return HttpNotFound();
            }

            fortbewegungsmittel.Kunde = kunde; //Gespeicherten Kundennamen zum Fortbewegungsmittel hinzufügen

            int? ablageId = 4;                 //Ablageort "Kunde" hinzufügen 
            Ablage ablage = db.Ablages.Find(ablageId);
            fortbewegungsmittel.Ablage = ablage;

            db.SaveChanges();

            return RedirectToAction("Index", "Fortbewegungsmittels"); 
        }

    // GET: Ausleihen/Details/5
    public ActionResult Leihen (int? id)
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
            ViewBag.fortbewegungsmittel = fortbewegungsmittel;
            return View(db.Kundes.ToList());  
        }

        public ActionResult Zurueckgeben (int? id)
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
            int? kundeId = fortbewegungsmittel.Kunde.Id;
            fortbewegungsmittel.Kunde.Fortbewegungsmittels.Remove(fortbewegungsmittel);
            fortbewegungsmittel.Kunde = null;
            // fortbewegungsmittel.Ablage.Fortbewegungsmittels.Remove(fortbewegungsmittel); //Ablageort entfernen (neu hinzugefügt)

            int? ablageId = 5;                            //Ablageort Shop hinzufügen (neu hinzugefügt)
            Ablage ablage = db.Ablages.Find(ablageId);
            fortbewegungsmittel.Ablage = ablage;

            db.SaveChanges();
            return RedirectToAction("Rückgabe", "Ausleihen", new { id = kundeId });
        }


        public ActionResult Rückgabe (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            ViewBag.kunde = kunde;
            return View(kunde.Fortbewegungsmittels.ToList());      
        }

    }
}

        