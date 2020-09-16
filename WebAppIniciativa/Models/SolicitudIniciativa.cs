using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppIniciativa.Models
{
    public class SolicitudIniciativa
    {
        [Display(Name = "Nro Correlativo")]
        public string nroCorrelativo { get; set; }
        public int codCli { get; set; }
        [Display(Name = "Eje Estratégico")]
        public string codEje { get; set; }
        [Display(Name = "Nombre Eje")]
        public string nomEje { get; set; }
        [Display(Name = "Requerimiento")]
        public string codReq { get; set; }
        [Display(Name = "Nombre Requerimiento")]
        public string nomReq { get; set; }
        [Display(Name = "Fecha de Solicitud")]
        public DateTime fecSol { get; set; }
        [Display(Name = "Nombre de la Iniciativa(max.75 caracteres)")]
        [RegularExpression(@"^[\W\w ]{1,75}$", ErrorMessage = "Solo permite 75 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar el nombre de la iniciativa")]
        public string nomIni { get; set; }
        [Display(Name = "Descripción de la Iniciativa (max.240 caracteres)")]
        [RegularExpression(@"^[\W\w ]{1,240}$", ErrorMessage = "Solo permite 240 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar la descripción de la iniciativa")]
        public string desIni { get; set; }
        [Display(Name = "Objetivo de la Iniciativa (max.300 caracteres)")]
        [RegularExpression(@"^[\W\w ]{1,300}$", ErrorMessage = "Solo permite 300 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar el objetivo de la iniciativa")]
        public string objIni { get; set; }
        [Display(Name = "Beneficio de la Iniciativa (max.500 caracteres)")]
        [RegularExpression(@"^[\W\w ]{1,500}$", ErrorMessage = "Solo permite 500 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar el beneficio de la iniciativa")]
        public string benIni { get; set; }
        [Display(Name = "Impacto de no ejecutar la Iniciativa")]
        public int codImp { get; set; }
        [Display(Name = "Escala del Impacto")]
        public string nomImp { get; set; }
        [Display(Name = "Descripción Impacto")]
        [RegularExpression(@"^[\W\w ]{1,50}$", ErrorMessage = "Solo permite 50 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar descripción de impacto")]
        public string desImp { get; set; }
        [Display(Name = "Mes de Inicio")]
        public DateTime fecIni { get; set; }
        [Display(Name = "Mes de Termino")]
        public DateTime fecTer { get; set; }
        [Display(Name = "Gerencia sponsor")]
        public int codGer { get; set; }
        [Display(Name = "Nombre de Gerencia Sponsor")]
        public string nomGer { get; set; }
        [Display(Name = "Jefatura solicitante")]
        public int codJef { get; set; }
        [Display(Name = "Nombre de Jefatura Solicitante")]
        public string nomJef { get; set; }
        [Display(Name = "Capa de Red")]
        public int codCap { get; set; }
        [Display(Name = "Nombre de Capa de Red")]
        public string nomCap { get; set; }
        [Display(Name = "Ubicación ¿Dónde?")]
        [RegularExpression(@"^[\W\w ]{1,100}$", ErrorMessage = "Solo permite 100 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar la ubicación")]
        public string ubicacion { get; set; }
        [Display(Name = "Tipo de Iniciativa")]
        public int codTip { get; set; }
        [Display(Name = "Nombre del Tipo de Iniciativa")]
        public string nomTip { get; set; }
        [Display(Name = "Descripción Tipo de Iniciativa")]
        [RegularExpression(@"^[\W\w ]{1,50}$", ErrorMessage = "Solo permite 50 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar la descripción del tipo de iniciativa")]
        public string desTip { get; set; }
        [Display(Name = "Anexos")]
        public int codAne { get; set; }
        [Display(Name = "Nombre de Anexo")]
        public string nomAne { get; set; }
        [Display(Name = "Descripción Anexo")]
        [RegularExpression(@"^[\W\w ]{1,50}$", ErrorMessage = "Solo permite 50 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar la descripción del anexo")]
        public string desAne { get; set; }
        [Display(Name = "Business Case")]
        public bool busCase { get; set; }
        [Display(Name = "Business Case")]
        public string nomBusCase { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
    }
}