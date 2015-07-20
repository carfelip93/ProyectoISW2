using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Inventario
    {
       
        public Prueba Prueba { get; set; }
        public Manual Manual { get; set; }
        public Lapices Lapices { get; set; }
        public Proyector Proyector { get; set; }

         // este es el campo que se renderizará como textbox y podremos filtrar
        public string NombrePrueba { get; set; }
        public string NombreManual { get; set; }
        public string NombreLapices { get; set; }
        public string NombreProyector { get; set; }

    // lista de empleados filtrados
        public List<Prueba> ListaDePruebas { get; set; }
        public List<Manual> ListaDeManuales { get; set; }
        public List<Lapices> ListaDeLapices { get; set; }
        public List<Proyector> ListaDeProyectores { get; set; }

        public Inventario()
        {
        // en el contructor tenemos que inicializar la lista
        ListaDePruebas = new List<Prueba>();
        ListaDeManuales = new List<Manual>();
        ListaDeLapices = new List<Lapices>();
        ListaDeProyectores = new List<Proyector>(); 
        }
        }
}