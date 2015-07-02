using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Context
{
    public class ProyectoISW2Context :DbContext
    {
        public System.Data.Entity.DbSet<ProyectoISW2.Models.Prueba> Pruebas { get; set; }

        public System.Data.Entity.DbSet<ProyectoISW2.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ProyectoISW2.Models.Lapices> Lapices { get; set; }
    }
}