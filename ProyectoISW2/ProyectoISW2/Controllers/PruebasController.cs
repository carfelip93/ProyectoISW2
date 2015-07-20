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
    public class PruebasController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();

        // GET: Pruebas
        public ActionResult Index()
        {
            return View(db.Pruebas.ToList());
        }

        // GET: Pruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // GET: Pruebas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pruebas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cantidad,Seccion")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                prueba.Nombre = prueba.Nombre.ToUpper();
                prueba.Seccion = prueba.Seccion.ToUpper();
                db.Pruebas.Add(prueba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prueba);
        }

        // GET: Pruebas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Cantidad,Seccion")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prueba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prueba);
        }

        // GET: Pruebas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prueba prueba = db.Pruebas.Find(id);
            db.Pruebas.Remove(prueba);
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

        [HttpPost]
        public JsonResult GetManufacturers()
        {
            ProyectoISW2Context db = new ProyectoISW2Context();
            string searchValue = Request.Params["filter[filters][0][value]"];
            IList<Prueba> pruebas = BuildManufacturersList()
                .Where(x => x.Nombre.StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return Json(pruebas);
        }

        private IList<Prueba> BuildManufacturersList()
        {
            IList<Prueba> pruebas = new List<Prueba>();
            ProyectoISW2Context db = new ProyectoISW2Context();
            var query = (from p in db.Pruebas

                         select p).ToList();
            foreach (Prueba prueba in query)
            {
                pruebas.Add(prueba);
            }

            return pruebas;
        } 
       
    }
}
