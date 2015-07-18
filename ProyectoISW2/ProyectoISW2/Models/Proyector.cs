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

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en el modelo.")]
        [StringLength(50, ErrorMessage =
            "El modelo debe tener un maximo de 50 caracteres de longitud.")]
        [Required]
        public string Modelo { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en la marca.")]
        [StringLength(50, ErrorMessage =
            "la marca debe tener un maximo de 50 caracteres de longitud.")]
        [Required]
        public string Marca { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en la asignacion.")]
        [StringLength(50, ErrorMessage =
            "la asignacion debe tener un maximo de 50 caracteres de longitud.")]
        [Required]
        public string Asignacion { get; set; }
    }
}