﻿using DelegacionMAUI.Interfaz;
using DelegacionMAUI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Servicio
{
    public class CiudadanoLoginServicio : ICiudadanoLogin
    {
        private readonly HttpClient _httpClient;

        public CiudadanoLoginServicio()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://proygestordelegacion.runasp.net/")
            };

        }

        public async Task<List<Ciudadano>> GetUsuariosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Ciudadano>>("api/Ciudadano");
        }

        public async Task<Ciudadano> ObtenerUsuariosIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Ciudadano>($"api/Ciudadano/{id}");
        }
    }
}
