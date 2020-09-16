using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppIniciativa.Models
{
    public class DetalleIniciativa
    {
        public string nroCorrelativo { get; set; }
        public int nroItem { get; set; }
        [Display(Name = "Tipo de Inversión")]
        public int codInv { get; set; }
        public string nomInv { get; set; }
        [Display(Name = "Familia")]
        public int codFam { get; set; }
        public string nomFam { get; set; }
        [Display(Name ="Descripción")]
        [RegularExpression(@"^[\W\w ]{1,150}$", ErrorMessage = "Solo permite 150 caracteres")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Ingrese la descripción")]
        public string desItem { get; set; }
        [Display(Name = "Tipo de Sitio")]
        public int codSit { get; set; }
        public string nomSit { get; set; }
        [Display(Name = "Tipo de Estructura")]
        public int codEst { get; set; }
        public string nomEst { get; set; }
    }
}