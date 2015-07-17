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
        [Required]
        public string Ot { get; set; }
        [Required]
        public string Docente { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        
        [Required]
        public string Ubicacion { get; set; }

        public int LapicesId { get; set; }
        [ForeignKey("LapicesId")]
        public virtual Lapices Lapices { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de Lapices es obligatorio.")]
        public int CantidadLapices { get; set; }

        public int PruebaId { get; set; }
        [ForeignKey("PruebaId")]
        public virtual Prueba Prueba { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de Pruebas es obligatorio.")]
        public int CantidadPrueba { get; set; }

        public int ManualId { get; set; }
        [ForeignKey("ManualId")]
        public virtual Manual Manual { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de Manuales es obligatorio.")]
        public int CantidadManual { get; set; }

        public int ProyectorId { get; set; }
        [ForeignKey("ProyectorId")]
        public virtual Proyector Proyector { get; set; }
    }
}