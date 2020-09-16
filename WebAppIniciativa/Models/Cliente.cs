using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppIniciativa.Models
{
    public class Cliente
    {
        public int codCli { get; set; }
        public string nomCli { get; set; }
        public string apeCli { get; set; }
        public string dniCli { get; set; }
        public string dirCli { get; set; }
        public string emailCli { get; set; }
        public int tipo { get; set; }
    }
}