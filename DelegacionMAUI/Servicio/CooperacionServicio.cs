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
    public class CooperacionServicio : ICooperacion
    {
        private readonly HttpClient _httpClient;

        public CooperacionServicio()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://proygestordelegacion.runasp.net/")
            };

        }

        public async Task<List<Cooperacion>> GetCooperacionAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Cooperacion>>("api/Cooperacion");
        }

        public async Task<Cooperacion> ObtenerCooperacionPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Cooperacion>($"api/Cooperacion/{id}");
        }
    }
}
