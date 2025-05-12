using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Modelo
{
    public class Cooperacion
    {
        public int IdCooperacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaLimiteDePago { get; set; }
    }
}
