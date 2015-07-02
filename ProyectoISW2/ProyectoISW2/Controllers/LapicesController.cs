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
    public class LapicesController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();

        // GET: Lapices
        public ActionResult Index()
        {
            return View(db.Lapices.ToList());
        }

        // GET: Lapices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lapices lapices = db.Lapices.Find(id);
            if (lapices == null)
            {
                return HttpNotFound();
            }
            return View(lapices);
        }

        // GET: Lapices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lapices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad")] Lapices lapices)
        {
            if (ModelState.IsValid)
            {
                db.Lapices.Add(lapices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lapices);
        }

        // GET: Lapices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lapices lapices = db.Lapices.Find(id);
            if (lapices == null)
            {
                return HttpNotFound();
            }
            return View(lapices);
        }

        // POST: Lapices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad")] Lapices lapices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lapices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lapices);
        }

        // GET: Lapices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lapices lapices = db.Lapices.Find(id);
            if (lapices == null)
            {
                return HttpNotFound();
            }
            return View(lapices);
        }

        // POST: Lapices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lapices lapices = db.Lapices.Find(id);
            db.Lapices.Remove(lapices);
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
