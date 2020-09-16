using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppIniciativa.Models
{
    public class DetalleInversion
    {
        public string nro_correlativo { get; set; }
        public int nro_item { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Fecha")]
        public DateTime fec_inv { get; set; }
        [Display(Name = "Precio")]
        [RegularExpression(@"^[0-9]{1,15}[.]{0,1}[0-9]{0,2}$", ErrorMessage ="Valor decimal ej: 10.00")]
        public decimal precio { get; set; }
        [Display(Name = "Cantidad")]
        [Range(0, 10000, ErrorMessage = "Minimo 0, Maximo 10000")]
        public int cantidad { get; set; }
        public decimal total { get { return precio * cantidad; } }
    }
}