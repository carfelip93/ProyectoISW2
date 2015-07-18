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

        [Range(1, 10000, ErrorMessage = "Valor de 1 a 10000")]
        [Required]
        public int Cantidad { get; set; }
    }
}