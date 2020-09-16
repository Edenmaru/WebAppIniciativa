using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppIniciativa.Models
{
    public class ReporteIniciativa
    {
        public string nroCorrelativo { get; set; }
        public string codEje { get; set; }
        public string nomEje { get; set; }
        public string codReq { get; set; }
        public string nomReq { get; set; }
        public DateTime fechaSol { get; set;}
        public string nomIni { get; set; }
        public string desIni { get; set; }
        public string objIni { get; set; }
        public string benIni { get; set; }
        public string tipoImp { get; set; }
        public string desImp { get; set; }
        public DateTime fecIni { get; set; }
        public DateTime fecTer { get; set; }
        public string nomGer { get; set; }
        public string nomJef { get; set; }
        public string nomCap { get; set; }
        public string ubi { get; set; }
        public string tipoIni { get; set; }
        public string desTipoIni { get; set; }
        public string nomAne { get; set; }
        public string desAne { get; set; }
        public string bcase { get; set; }
        public string nomInv { get; set; }
        public string nomFam { get; set; }
        public string desItem { get; set; }
        public string nomSit { get; set; }
        public string nomEst { get; set; }
        public DateTime fechaInv { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal capex { get; set; }
    }
}