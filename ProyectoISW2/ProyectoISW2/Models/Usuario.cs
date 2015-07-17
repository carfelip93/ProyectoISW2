using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public string User { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en el nombre.")]
        [StringLength(8, MinimumLength = 3, ErrorMessage =
            "El nombre debe tener entre 3 y 8 caracteres de longitud.")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}