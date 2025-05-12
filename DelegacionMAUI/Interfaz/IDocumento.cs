using DelegacionMAUI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegacionMAUI.Interfaz
{
    public interface IDocumento
    {
        public Task<List<Documento>> GetDocumentoAsync();
    }
}
