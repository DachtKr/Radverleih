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
    public class LoginController : Controller
    {
        private RadverleihModelContainer db = new RadverleihModelContainer();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.Kundes.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
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
            return View(kunde);
        }
    }
}