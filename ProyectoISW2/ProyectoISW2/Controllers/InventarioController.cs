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
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index()
        {
            ProyectoISW2Context db = new ProyectoISW2Context();
            ViewBag.PruebaId = new SelectList(db.Pruebas, "Id", "Nombre");
            
            
            return View(new Inventario());
        }
        [HttpPost]
        public ActionResult Filtrar(Inventario viewmodel)
        {
            // para simplificar el ejemplo, en lugar de ir a buscar datos a la base de datos
            // llenamos el objeto con datos de mentira
            LlenarConDatosDummy(viewmodel);
            FiltrarRegistros(viewmodel);

            // devolvemos una vista parcial para renderizar la grilla
            return PartialView("Listado", viewmodel.ListaDePruebas);
        }

        private void FiltrarRegistros(Inventario viewmodel)
        {
            viewmodel.ListaDePruebas =
                viewmodel.ListaDePruebas.Where(l => l.Nombre.Contains(viewmodel.NombrePrueba.ToUpper())).ToList();
        }

        private void LlenarConDatosDummy(Inventario viewmodel)
        {
            using (var db = new ProyectoISW2Context())
            {
                var query = (from p in db.Pruebas
                            
                             select p).ToList();
                foreach (Prueba prueba in query) {

                    viewmodel.ListaDePruebas.Add(prueba);
                }
            
            }
        }
        [HttpPost]
           public JsonResult GetManufacturers() {
               ProyectoISW2Context db = new ProyectoISW2Context();
               string searchValue = Request.Params["filter[filters][0][value]"];
               IList<Prueba> pruebas = BuildManufacturersList()
                   .Where(x => x.Nombre.StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase)).ToList();
               return Json(pruebas);
           }
    
           private IList<Prueba> BuildManufacturersList() {
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