using DelegacionMAUI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Interfaz
{
    public interface ICiudadanoLogin
    {
        Task<List<Ciudadano>> GetUsuariosAsync();
        Task<Ciudadano> ObtenerUsuariosIdAsync(string id);
    }
}
