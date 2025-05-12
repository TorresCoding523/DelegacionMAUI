using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Modelo
{
    public class DocumentoSolicitado
    {
        public int IdDocumentoSolicitado { get; set; }
        public int IdDocumento { get; set; }
        public string IdCiudadanoSolicitante { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string IdUsuarioGenerador { get; set; }
        public DateTime? FechaPago { get; set; }
        public decimal MontoPagado { get; set; }
        public string IdUsuarioQueEntrega { get; set; }
        public string Finalidad { get; set; }
        public string Notas { get; set; }
    }
}
