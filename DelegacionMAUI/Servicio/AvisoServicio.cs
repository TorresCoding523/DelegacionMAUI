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
    public class AvisoServicio : IAviso
    {
        private readonly HttpClient _httpClient;

        public AvisoServicio()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://proygestordelegacion.runasp.net/")
            };

        }

        public async Task<List<Aviso>> GetAvisoAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Aviso>>("api/Aviso");
        }
    }
}
