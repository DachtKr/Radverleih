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
            Kunde kunde = db.Kundes.Find(kundeId);

            if (kunde == null)
            {
                return HttpNotFound();
            }

            if (fzgId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fortbewegungsmittel fortbewegungsmittel = db.Fortbewegungsmittels.Find(fzgId);
            if (fortbewegungsmittel == null)
            {
                return HttpNotFound();
            }
            fortbewegungsmittel.Kunde = kunde;
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
    }
}

        