using DelegacionMAUI.Interfaz;
using DelegacionMAUI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Servicio
{
    public class CooperacionesDeCiudadanoServicio : ICooperacionesDeCiudadano
    {
        private readonly HttpClient _httpClient;

        public CooperacionesDeCiudadanoServicio()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://proygestordelegacion.runasp.net/")
            };

        }

        public async Task<List<CooperacionesDeCiudadano>> GetCooperacionesDeCiudadanoAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CooperacionesDeCiudadano>>("api/CooperacionesDeCiudadano");
        }
    }
}
