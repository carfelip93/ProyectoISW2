using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Prueba
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre Prueba")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en el nombre.")]
        [StringLength(50, ErrorMessage =
            "El nombre debe tener un maximo de 50 caracteres de longitud.")]
        [Required]
        public string Nombre { get; set; }

        [Range(1, 10000, ErrorMessage = "Valor de 1 a 10000")]
        [Required]
        public int Cantidad { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en la seccion.")]
        
        [Required]
        public string Seccion { get; set; }
    }
}