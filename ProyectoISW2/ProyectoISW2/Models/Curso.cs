using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "OT")]
        [StringLength(20, ErrorMessage =
            "El identificador OT debe tener un maximo de 20 caracteres de longitud.")]
        [Required]
        public string Ot { get; set; }

        [RegularExpression(@"^[ña-zÑA-ZáéíóúÁÉÍÓÚ''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en el docente.")]
        [Required]
        public string Docente { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [RegularExpression(@"^[ña-zÑA-ZáéíóúÁÉÍÓÚ''-'\s]{1,40}$", ErrorMessage =
            "Los números y caracteres especiales no están permitidos en la ubicacion.")]
        [Required]
        public string Ubicacion { get; set; }

        [Display(Name = "Cantidad Lapices")]
        public int LapicesId { get; set; }
        [ForeignKey("LapicesId")]
        public virtual Lapices Lapices { get; set; }

        [Range(0, 10000, ErrorMessage = "Valor de 0 a 10000")]
        [Display(Name = "Cantidad Lapices")]
        [Required]
        public int CantidadLapices { get; set; }

        [Display(Name = "Pruebas")]
        public int PruebaId { get; set; }
        [ForeignKey("PruebaId")]
        public virtual Prueba Prueba { get; set; }

        [Range(0, 10000, ErrorMessage = "Valor de 0 a 10000")]
        [Display(Name = "Cantidad Pruebas")]
        [Required]
        public int CantidadPrueba { get; set; }

        [Display(Name = "Manual")]
        public int ManualId { get; set; }
        [ForeignKey("ManualId")]
        public virtual Manual Manual { get; set; }

        [Range(0, 10000, ErrorMessage = "Valor de 0 a 10000")]
        [Display(Name = "Cantidad Manuales")]
        [Required]
        public int CantidadManual { get; set; }

        [Display(Name = "Proyector")]
        public int ProyectorId { get; set; }
        [ForeignKey("ProyectorId")]
        public virtual Proyector Proyector { get; set; }
    }
}