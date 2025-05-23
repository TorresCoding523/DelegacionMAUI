using DelegacionMAUI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Servicio
{
    public class InfoDelegacionServicio
    {
        private readonly HttpClient _httpClient;

        public InfoDelegacionServicio()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://proygestordelegacion.runasp.net/")
            };
        }

        public async Task<List<InfoDelegacion>> IInfoDelegacion()
        {
            return await _httpClient.GetFromJsonAsync<List<InfoDelegacion>>("api/InfoDelegacion");
        }
    }
}
