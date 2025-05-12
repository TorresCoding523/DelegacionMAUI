using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Modelo
{
    public class Documento
    {
        public int IdDocumento { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public string URLPlantilla { get; set; }
        public string Notas { get; set; }
    }
}
