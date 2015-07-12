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
    public class StocksController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();

        // GET: Stocks
        public ActionResult Index()
        {
            var stocks = db.Stocks.Include(s => s.Lapices).Include(s => s.Manual).Include(s => s.Prueba);
            return View(stocks.ToList());
        }

        // GET: Stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id");
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre");
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre");
            return View();
        }

        // POST: Stocks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LapicesId,CantidadLapices,PruebaId,CantidadPrueba,ManualId,CantidadManual")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id", stock.LapicesId);
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre", stock.ManualId);
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre", stock.PruebaId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id", stock.LapicesId);
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre", stock.ManualId);
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre", stock.PruebaId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LapicesId,CantidadLapices,PruebaId,CantidadPrueba,ManualId,CantidadManual")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LapicesId = new SelectList(db.Lapices, "Id", "Id", stock.LapicesId);
            ViewBag.ManualId = new SelectList(db.Manuals, "Id", "Nombre", stock.ManualId);
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre", stock.PruebaId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stocks.Find(id);
            db.Stocks.Remove(stock);
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
