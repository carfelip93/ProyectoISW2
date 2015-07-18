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

        [Display(Name = "Usuario")]
        [Required]
        public string User { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en el nombre.")]
        [StringLength(20, ErrorMessage =
            "El nombre debe tener un maximo de 20 caracteres de longitud.")]
        [Required]
        public string Nombre { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en el apellido.")]
        
        [Required]
        public string Apellido { get; set; }
        
        [Required]
        public string Contraseña { get; set; }
        
        [Required]
        public string Rol { get; set; }
    }
}