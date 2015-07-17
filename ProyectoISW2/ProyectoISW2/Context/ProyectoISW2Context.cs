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

        public System.Data.Entity.DbSet<ProyectoISW2.Models.Manual> Manuals { get; set; }

        public System.Data.Entity.DbSet<ProyectoISW2.Models.Proyector> Proyectors { get; set; }

        public System.Data.Entity.DbSet<ProyectoISW2.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoISW2.Models.Stock> Stocks { get; set; }

     

        
    }
}