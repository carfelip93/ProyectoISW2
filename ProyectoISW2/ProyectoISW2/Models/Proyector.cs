using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Proyector
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Asignacion { get; set; }
    }
}