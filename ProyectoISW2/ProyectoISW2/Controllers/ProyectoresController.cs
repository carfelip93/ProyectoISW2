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
    public class ProyectoresController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();

        // GET: Proyectores
        public ActionResult Index()
        {
            return View(db.Proyectors.ToList());
        }

        // GET: Proyectores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyector proyector = db.Proyectors.Find(id);
            if (proyector == null)
            {
                return HttpNotFound();
            }
            return View(proyector);
        }

        // GET: Proyectores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyectores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Modelo,Marca,Asignacion")] Proyector proyector)
        {
            if (ModelState.IsValid)
            
            {

                proyector.Marca = proyector.Marca.ToUpper();
                proyector.Modelo = proyector.Modelo.ToUpper();
                proyector.Asignacion = proyector.Asignacion.ToUpper();
                db.Proyectors.Add(proyector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proyector);
        }

        // GET: Proyectores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyector proyector = db.Proyectors.Find(id);
            if (proyector == null)
            {
                return HttpNotFound();
            }
            return View(proyector);
        }

        // POST: Proyectores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Modelo,Marca,Asignacion")] Proyector proyector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyector);
        }

        // GET: Proyectores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyector proyector = db.Proyectors.Find(id);
            if (proyector == null)
            {
                return HttpNotFound();
            }
            return View(proyector);
        }

        // POST: Proyectores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyector proyector = db.Proyectors.Find(id);
            db.Proyectors.Remove(proyector);
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
