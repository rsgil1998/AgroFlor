using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLLAgroFlor;

namespace AgroFlorWeb.Controllers
{
    public class floricolasController : Controller
    {
        private dbAgroFlorEntities db = new dbAgroFlorEntities();

        // GET: floricolas
        public ActionResult Index()
        {
            var floricola = db.floricola.Include(f => f.config);
            return View(floricola.ToList());
        }

        // GET: floricolas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            floricola floricola = db.floricola.Find(id);
            if (floricola == null)
            {
                return HttpNotFound();
            }
            return View(floricola);
        }

        // GET: floricolas/Create
        public ActionResult Create()
        {
            ViewBag.config_id = new SelectList(db.config, "id", "medidas");
            return View();
        }

        // POST: floricolas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,config_id")] floricola floricola)
        {
            if (ModelState.IsValid)
            {
                db.floricola.Add(floricola);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.config_id = new SelectList(db.config, "id", "medidas", floricola.config_id);
            return View(floricola);
        }

        // GET: floricolas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            floricola floricola = db.floricola.Find(id);
            if (floricola == null)
            {
                return HttpNotFound();
            }
            ViewBag.config_id = new SelectList(db.config, "id", "medidas", floricola.config_id);
            return View(floricola);
        }

        // POST: floricolas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,config_id")] floricola floricola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floricola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.config_id = new SelectList(db.config, "id", "medidas", floricola.config_id);
            return View(floricola);
        }

        // GET: floricolas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            floricola floricola = db.floricola.Find(id);
            if (floricola == null)
            {
                return HttpNotFound();
            }
            return View(floricola);
        }

        // POST: floricolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            floricola floricola = db.floricola.Find(id);
            db.floricola.Remove(floricola);
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
