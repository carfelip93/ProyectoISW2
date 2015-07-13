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
        public ActionResult Create(int? CantidadLapices, int LapicesId, int? CantidadPrueba, int PruebaId, int? CantidadManual, int ManualId,
            [Bind(Include = "Id,LapicesId,CantidadLapices,PruebaId,CantidadPrueba,ManualId,CantidadManual")] Stock stock)
        {
            
           
           
                if (ModelState.IsValid)
                {
                    ViewBag.CantidadLapicess = CantidadLapices;
                    ViewBag.LapicesIdd = LapicesId;
                    ViewBag.CantidadPruebass = CantidadPrueba;
                    ViewBag.PruebasIdd = PruebaId;
                    ViewBag.Cantidadmanualess = CantidadManual;
                    ViewBag.ManualesIdd = ManualId;


                    int cantlbd = 0, cantlf = 0, cantpbd = 0, cantpf = 0, cantmbd = 0, cantmf = 0;

                    var queryl = (from l in db.Lapices
                                  where l.Id == LapicesId
                                  select l);

                    if (queryl.Count() > 0 && queryl != null)
                    {
                        Lapices lapices = queryl.First();

                        cantlbd = Convert.ToInt32(lapices.Cantidad);
                        cantlf = cantlbd + Convert.ToInt32(CantidadLapices);
                        lapices.Cantidad = cantlf;

                    }
                   
                    var queryp = (from p in db.Pruebas
                                  where p.Id == PruebaId
                                  select p);

                    if (queryp.Count() > 0 && queryp != null)
                    {
                        Prueba prueba = queryp.First();

                        cantpbd = Convert.ToInt32(prueba.Cantidad);
                        cantpf = cantpbd + Convert.ToInt32(CantidadPrueba);
                        prueba.Cantidad = cantpf;

                    }
                    var querym = (from m in db.Manuals
                                  where m.Id == ManualId
                                  select m);

                    if (querym.Count() > 0 && querym != null)
                    {
                        Manual manual = querym.First();

                        cantmbd = Convert.ToInt32(manual.Cantidad);
                        cantmf = cantmbd + Convert.ToInt32(CantidadManual);
                        manual.Cantidad = cantmf;

                    }

                    if (cantlf < cantlbd)
                    {
                        ViewBag.Message = "Ingrese Valor Positivo";
                    }
                    else
                    {
                        if (cantpf < cantpbd)
                        {
                            ViewBag.Message = "Ingrese Valor Positivo";
                        }
                        else
                        {
                            if (cantmf < cantmbd)
                            {
                                ViewBag.Message = "Ingrese Valor Positivo";
                            }
                            else
                            {
                                db.Stocks.Add(stock);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                        }
                    }
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
