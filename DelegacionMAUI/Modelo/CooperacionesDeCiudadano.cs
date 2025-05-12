using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Modelo
{
    public class CooperacionesDeCiudadano
    {
        public int Id { get; set; }
        public string IdCiudadano { get; set; }
        public int IdCooperacion { get; set; }
        public DateTime FechaDePago { get; set; }
        public string idUsuarioReceptor { get; set; }
        public bool EsParcial { get; set; }
        public string Notas { get; set; }
    }
}
