using ProyectoISW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoISW2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                return Redirect("/Usuarios/Login");
            }

            return Redirect("/Usuarios/Inventario");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");

        }
    }
}