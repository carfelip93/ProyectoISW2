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
    public class UsuariosController : Controller
    {
        private ProyectoISW2Context db = new ProyectoISW2Context();


      
        public ActionResult Inventario()
        {
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            return View();
        }
        
        // GET: Usuarios
        public ActionResult Index()
        {
            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string User, [Bind(Include = "Id,,User,Nombre,Apellido,Contraseña,Rol")] Usuario usuario)
        {
            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            using (var db = new ProyectoISW2Context())
            {
                var query = (from u in db.Usuarios
                             where u.User == User
                             select u);
                // 


                if (query.Count() > 0 && query != null)
                {
                    
                        ViewBag.MyErrorMessage = "Error";
                        string x = ViewBag.MyErrorMessage;
                    
                    

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        usuario.Nombre= usuario.Nombre.ToUpper();
                        usuario.Apellido = usuario.Apellido.ToUpper();
                        usuario.Rol = usuario.Rol.ToUpper();
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {


            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Nombre,Apellido,Contraseña,Rol")] Usuario usuario)
        {
            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                usuario.Nombre = usuario.Nombre.ToUpper();
                usuario.Apellido = usuario.Apellido.ToUpper();
                usuario.Rol = usuario.Rol.ToUpper();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {

            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            string rol;
            rol = Convert.ToString(Session["rol"]);
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }
            if (rol != ("ADMINISTRADOR"))
            {
                return Redirect("/Usuarios/Inventario");
            }
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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


        public ActionResult Login()
        {
            if (Session["userId"] != null)
            {
                return Redirect("/Usuarios/Inventario");
            }
            else {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Login(string User, string Contraseña)
        {
            ViewBag.User = User;
            ViewBag.Contraseña = Contraseña;
            if (Session["userId"] != null)
            {
                return Redirect("/Usuarios/Inventario");
            }
            using (var db = new ProyectoISW2Context())
            {
                var query = (from u in db.Usuarios
                             where u.User == User
                             select u);
                // 

                

                if (query.Count() > 0 && query != null)
                {
                    Usuario myUser = query.First();


                    if (Contraseña == myUser.Contraseña && User == myUser.User)
                    {
                        Session.Add("userId", myUser.Id);
                        Session.Add("username", myUser.Nombre);
                        Session.Add("rol", myUser.Rol);
                        return Redirect("/Home/");
                    }
                    else
                    {
                        ViewBag.MyErrorMessage = "Error";
                        string x = ViewBag.MyErrorMessage;
                        return View();
                    }
                    
                    
                    


                }
                else
                {
                    ViewBag.MyErrorMessage = "Error";
                    string x = ViewBag.MyErrorMessage;
                    return View();
                    
                    
                }
            }
        }
                    
                    
                
                
                    


                    
                    
                    
                    


                
            }
        }
        //
        
           