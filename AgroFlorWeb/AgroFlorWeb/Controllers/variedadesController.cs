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
    public class variedadesController : Controller
    {
        private dbAgroFlorEntities db = new dbAgroFlorEntities();

        // GET: variedades
        public ActionResult Index()
        {
            return View(db.variedades.ToList());
        }

        // GET: variedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            variedades variedades = db.variedades.Find(id);
            if (variedades == null)
            {
                return HttpNotFound();
            }
            return View(variedades);
        }

        // GET: variedades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: variedades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,total_matas")] variedades variedades)
        {
            if (ModelState.IsValid)
            {
                db.variedades.Add(variedades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(variedades);
        }

        // GET: variedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            variedades variedades = db.variedades.Find(id);
            if (variedades == null)
            {
                return HttpNotFound();
            }
            return View(variedades);
        }

        // POST: variedades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,total_matas")] variedades variedades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variedades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(variedades);
        }

        // GET: variedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            variedades variedades = db.variedades.Find(id);
            if (variedades == null)
            {
                return HttpNotFound();
            }
            return View(variedades);
        }

        // POST: variedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            variedades variedades = db.variedades.Find(id);
            db.variedades.Remove(variedades);
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
