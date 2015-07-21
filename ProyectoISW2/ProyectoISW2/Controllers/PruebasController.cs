﻿using System;
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
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            return View(db.Pruebas.ToList());
        }

        // GET: Pruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            return View();
        }

        // POST: Pruebas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cantidad,Seccion")] Prueba prueba)
        {
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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

            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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

        public ActionResult Stock(int? id)
        {
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
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
        
        public ActionResult Stock(int? Id,int? Cantidad)
        {

            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
           
         ViewBag.PruebaIdd = Id;
         ViewBag.CantidadPruebass = Cantidad;
            if (ModelState.IsValid)
            {
                int cantpbd, cantpf;
               
                var queryp = (from l in db.Pruebas
                              where l.Id == Id
                              select l);


                
                
                if (queryp.Count() > 0 && queryp != null)
                {
                    Prueba prueba = queryp.First();

                    cantpbd = Convert.ToInt32(prueba.Cantidad);
                    cantpf = cantpbd + Convert.ToInt32(Cantidad);
                    if (Cantidad < 0)
                    {
                        ViewBag.Message = "Pruebas no suficientes";
                    }
                    else{
                    prueba.Cantidad = cantpf;
                     db.SaveChanges();
                    return Redirect("/Inventario/");
                    }
                    

                }

              }
                return View();
            }
            
        }
        

       
    }

