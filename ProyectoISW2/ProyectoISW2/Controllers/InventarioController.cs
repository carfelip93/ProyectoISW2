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
        public ActionResult Index(Inventario viewmodel)
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
            return PartialView("ListadoPruebas", viewmodel.ListaDePruebas);
        }

        private void FiltrarRegistros(Inventario viewmodel)
        {
            if (viewmodel.NombrePrueba != null)
            {

                viewmodel.ListaDePruebas =
                    viewmodel.ListaDePruebas.Where(l => l.Nombre.Contains(viewmodel.NombrePrueba.ToUpper())).ToList();
            }
            else
            {
                viewmodel.ListaDePruebas.Clear();
            }
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

        public ActionResult FiltrarManuales(Inventario viewmodel)
        {
            // para simplificar el ejemplo, en lugar de ir a buscar datos a la base de datos
            // llenamos el objeto con datos de mentira
            LlenarConDatosDummyManuales(viewmodel);
            FiltrarRegistrosManuales(viewmodel);

            // devolvemos una vista parcial para renderizar la grilla
            return PartialView("ListadoManuales", viewmodel.ListaDeManuales);
        }

        private void FiltrarRegistrosManuales(Inventario viewmodel)
        {
            if (viewmodel.NombreManual != null)
            {
                viewmodel.ListaDeManuales =
                   viewmodel.ListaDeManuales.Where(l => l.Nombre.Contains(viewmodel.NombreManual.ToUpper())).ToList();
            }
            else
            {
                viewmodel.ListaDeManuales.Clear();
            }

           
        }

        private void LlenarConDatosDummyManuales(Inventario viewmodel)
        {
            using (var db = new ProyectoISW2Context())
            {
                var query = (from p in db.Manuals

                             select p).ToList();
                foreach (Manual manual in query)
                {

                    viewmodel.ListaDeManuales.Add(manual);
                }

            }
        }

        public ActionResult FiltrarProyectores(Inventario viewmodel)
        {
            // para simplificar el ejemplo, en lugar de ir a buscar datos a la base de datos
            // llenamos el objeto con datos de mentira
            LlenarConDatosDummyProyectores(viewmodel);
            FiltrarRegistrosProyectores(viewmodel);

            // devolvemos una vista parcial para renderizar la grilla
            return PartialView("ListadoProyectores", viewmodel.ListaDeProyectores);
        }

        private void FiltrarRegistrosProyectores(Inventario viewmodel)
        {
            if (viewmodel.NombreProyector != null)
            {
                viewmodel.ListaDeProyectores =
                   viewmodel.ListaDeProyectores.Where(l => l.Marca.Contains(viewmodel.NombreProyector.ToUpper())).ToList();
            }
            else
            {
                viewmodel.ListaDeProyectores.Clear();
            }


        }

        private void LlenarConDatosDummyProyectores(Inventario viewmodel)
        {
            using (var db = new ProyectoISW2Context())
            {
                var query = (from p in db.Proyectors

                             select p).ToList();
                foreach (Proyector proyector in query)
                {

                    viewmodel.ListaDeProyectores.Add(proyector);
                }

            }
        }

        public ActionResult FiltrarLapices(Inventario viewmodel)
        {
            // para simplificar el ejemplo, en lugar de ir a buscar datos a la base de datos
            // llenamos el objeto con datos de mentira
            LlenarConDatosDummyLapices(viewmodel);
            

            // devolvemos una vista parcial para renderizar la grilla
            return PartialView("ListadoLapices", viewmodel.ListaDeLapices);
        }

        

        private void LlenarConDatosDummyLapices(Inventario viewmodel)
        {
            using (var db = new ProyectoISW2Context())
            {
                var query = (from p in db.Lapices

                             select p).ToList();
                foreach (Lapices lapices in query)
                {

                    viewmodel.ListaDeLapices.Add(lapices);
                }

            }
        }

        
    }
}