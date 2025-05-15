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
        Task<List<Cooperacion>> GetCooperacionAsync();
        Task<Cooperacion> ObtenerCooperacionPorIdAsync(int id);
    }
}
