using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoISW2.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
       
        public int LapicesId { get; set; }
        [ForeignKey("LapicesId")]
        public virtual Lapices Lapices { get; set; }

        [Range(1, 10000, ErrorMessage = "Valor de 1 a 10000")]
        [Display(Name = "Cantidad Lapices")]
        [Required]
        public int CantidadLapices { get; set; }

        public int PruebaId { get; set; }
        [ForeignKey("PruebaId")]
        public virtual Prueba Prueba { get; set; }

        [Range(1, 10000, ErrorMessage = "Valor de 1 a 10000")]
        [Display(Name = "Cantidad Pruebas")]
        [Required]
        public int CantidadPrueba { get; set; }

        public int ManualId { get; set; }
        [ForeignKey("ManualId")]
        public virtual Manual Manual { get; set; }

        [Display(Name = "Cantidad Manuales")]
        [Range(1,10000, ErrorMessage = "Valor de 1 a 10000")]
        [Required]
        public int CantidadManual { get; set; }
    }
}