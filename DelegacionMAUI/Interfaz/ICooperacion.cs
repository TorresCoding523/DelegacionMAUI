using DelegacionMAUI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Interfaz
{
    public interface ICooperacion
    {
        public Task<List<Cooperacion>> GetCooperacionAsync();
    }
}
