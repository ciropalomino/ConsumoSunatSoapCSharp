using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSoap
{
    public class Comprobante
    {
        public String username { get; set; }
        public String password { get; set; }
        public String rucComprobante { get; set; }

        public String tipoComprobante { get; set; }
        public String serieComprobante { get; set; }
        public String numeroComprobante { get; set; }
        public String respuetas { get; set; }

        public Comprobante(string username, string password, string rucComprobante, string tipoComprobante, string serieComprobante, string numeroComprobante) 
    
        {
            this.username = username;
            this.password = password;
            this.rucComprobante = rucComprobante;

            this.tipoComprobante = tipoComprobante;
            this.serieComprobante = serieComprobante;
            this.numeroComprobante = numeroComprobante;
        }

        public Comprobante(string tipoComprobante, string serieComprobante, string numeroComprobante)
        {
            this.tipoComprobante = tipoComprobante;
            this.serieComprobante = serieComprobante;
            this.numeroComprobante = numeroComprobante;
        }
    }
}
