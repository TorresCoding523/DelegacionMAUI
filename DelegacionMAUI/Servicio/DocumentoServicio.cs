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
    public class DocumentoServicio : IDocumento
    {
        private readonly HttpClient _httpClient;

        public DocumentoServicio()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://proygestordelegacion.runasp.net/")
            };

        }

        public async Task<List<Documento>> GetDocumentoAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Documento>>("api/Documento");
        }
    }
}
