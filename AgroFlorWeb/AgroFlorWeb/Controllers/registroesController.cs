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
    public class registroesController : Controller
    {
        private dbAgroFlorEntities db = new dbAgroFlorEntities();

        // GET: registroes
        public ActionResult Index()
        {
            var registro = db.registro.Include(r => r.floricola).Include(r => r.variedades);
            return View(registro.ToList());
        }

        // GET: registroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro registro = db.registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: registroes/Create
        public ActionResult Create()
        {
            ViewBag.floricola_id = new SelectList(db.floricola, "id", "nombre");
            ViewBag.variedad_id = new SelectList(db.variedades, "id", "nombre");
            return View();
        }

        // POST: registroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,variedad_id,floricola_id,fecha,bonche_med,precio_tall_exp,tall_nacional,total_tallos,precio_nac")] registro registro)
        {
            if (ModelState.IsValid)
            {
                db.registro.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.floricola_id = new SelectList(db.floricola, "id", "nombre", registro.floricola_id);
            ViewBag.variedad_id = new SelectList(db.variedades, "id", "nombre", registro.variedad_id);
            return View(registro);
        }

        // GET: registroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro registro = db.registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.floricola_id = new SelectList(db.floricola, "id", "nombre", registro.floricola_id);
            ViewBag.variedad_id = new SelectList(db.variedades, "id", "nombre", registro.variedad_id);
            return View(registro);
        }

        // POST: registroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,variedad_id,floricola_id,fecha,bonche_med,precio_tall_exp,tall_nacional,total_tallos,precio_nac")] registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.floricola_id = new SelectList(db.floricola, "id", "nombre", registro.floricola_id);
            ViewBag.variedad_id = new SelectList(db.variedades, "id", "nombre", registro.variedad_id);
            return View(registro);
        }

        // GET: registroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro registro = db.registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registro registro = db.registro.Find(id);
            db.registro.Remove(registro);
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
