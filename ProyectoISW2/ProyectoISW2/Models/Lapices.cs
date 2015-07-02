using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Lapices
    {
        [Key]
        public int Id { get; set; }
        
        public int Cantidad { get; set; }
    }
}