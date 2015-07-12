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
    public class CursosController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursoes = db.Cursoes.Include(c => c.Lapices).Include(c => c.Manual).Include(c => c.Proyector).Include(c => c.Prueba);
            return View(cursoes.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id");
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre");
            ViewBag.ProyectorId = new SelectList(db.Proyectors, "Id", "Modelo");
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre");
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int CantidadLapices,int LapicesId, [Bind(Include = "Id,Ot,Docente,Fecha,Ubicacion,LapicesId,CantidadLapices,PruebaId,CantidadPrueba,ManualId,CantidadManual,ProyectorId")] Curso curso)
        {
            
            if (ModelState.IsValid)
            {
                ViewBag.CantidadLapicess = CantidadLapices;
                ViewBag.LapicesIdd = LapicesId;

                int cantbd = 0, cantf = 0;
                var queryl = (from l in db.Lapices
                              where l.Id == LapicesId
                              select l);

                if (queryl.Count() > 0 && queryl != null)
                {
                    Lapices lapices = queryl.First();

                    cantbd = Convert.ToInt32(lapices.Cantidad);
                    cantf = cantbd - CantidadLapices;
                    lapices.Cantidad = cantf;

                    
                    db.SaveChanges();

                }
                db.Cursoes.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            

            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id", curso.LapicesId);
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre", curso.ManualId);
            ViewBag.ProyectorId = new SelectList(db.Proyectors, "Id", "Modelo", curso.ProyectorId);
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre", curso.PruebaId);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id", curso.LapicesId);
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre", curso.ManualId);
            ViewBag.ProyectorId = new SelectList(db.Proyectors, "Id", "Modelo", curso.ProyectorId);
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre", curso.PruebaId);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ot,Docente,Fecha,Ubicacion,LapicesId,CantidadLapices,PruebaId,CantidadPrueba,ManualId,CantidadManual,ProyectorId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id", curso.LapicesId);
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre", curso.ManualId);
            ViewBag.ProyectorId = new SelectList(db.Proyectors, "Id", "Modelo", curso.ProyectorId);
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre", curso.PruebaId);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursoes.Find(id);
            db.Cursoes.Remove(curso);
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
