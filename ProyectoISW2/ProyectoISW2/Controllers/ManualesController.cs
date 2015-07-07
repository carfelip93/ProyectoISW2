using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoISW2.Context;
using ProyectoISW2.Models;

namespace ProyectoISW2.Controllers
{
    public class ManualesController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();

        // GET: Manuales
        public ActionResult Index()
        {
            return View(db.Manuals.ToList());
        }

        // GET: Manuales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manual manual = db.Manuals.Find(id);
            if (manual == null)
            {
                return HttpNotFound();
            }
            return View(manual);
        }

        // GET: Manuales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manuales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cantidad,Seccion")] Manual manual)
        {
            if (ModelState.IsValid)
            {
                db.Manuals.Add(manual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manual);
        }

        // GET: Manuales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manual manual = db.Manuals.Find(id);
            if (manual == null)
            {
                return HttpNotFound();
            }
            return View(manual);
        }

        // POST: Manuales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Cantidad,Seccion")] Manual manual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manual);
        }

        // GET: Manuales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manual manual = db.Manuals.Find(id);
            if (manual == null)
            {
                return HttpNotFound();
            }
            return View(manual);
        }

        // POST: Manuales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manual manual = db.Manuals.Find(id);
            db.Manuals.Remove(manual);
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
