using DelegacionMAUI.Acceso;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class DocumentoSolicitadoDetallePages : ContentPage
{
    private readonly DocumentoSolicitado _documentoSolicitado;
    private readonly CiudadanoLoginServicio _ciudadanoLoginServicio = new();

    public DocumentoSolicitadoDetallePages(DocumentoSolicitado documentoSolicitado)
    {
        InitializeComponent();
        _documentoSolicitado = documentoSolicitado;
        _ = MostrarDetallesAsync();
    }

    private async Task MostrarDetallesAsync()
    {
        // Mostrar datos básicos
        if (Sesion.UsuarioActual != null)
        {
            IdCiudadanoSolicitanteLabel.Text = $"Ciudadano: {Sesion.UsuarioActual.Nombre} {Sesion.UsuarioActual.Apellidos}";
        }
        else
        {
            IdCiudadanoSolicitanteLabel.Text = "Ciudadano no identificado";
        }

        FechaSolicitudLabel.Text = $"Fecha: {_documentoSolicitado.FechaSolicitud:dd/MM/yyyy}";
        FechaEntregaLabel.Text = $"Fecha: {_documentoSolicitado.FechaEntrega:dd/MM/yyyy}";
        FechaPagoLabel.Text = $"Fecha: {_documentoSolicitado.FechaPago:dd/MM/yyyy}";
        MontoPagadoLabel.Text = _documentoSolicitado.MontoPagado.ToString("C");
        FinalidadLabel.Text = _documentoSolicitado.Finalidad;
        notasLabel.Text = _documentoSolicitado.Notas;

        try
        {
            // Obtener nombre del usuario que genera el documento
            var generador = await _ciudadanoLoginServicio.ObtenerUsuariosIdAsync(_documentoSolicitado.IdUsuarioGenerador);
            IdUsuarioGeneradorLabel.Text = generador != null ? $"{generador.Nombre} {generador.Apellidos}" : "Usuario no encontrado";

            // Obtener nombre del usuario que entrega el documento
            var entregador = await _ciudadanoLoginServicio.ObtenerUsuariosIdAsync(_documentoSolicitado.IdUsuarioQueEntrega);
            IdUsuarioQueEntregaLabel.Text = entregador != null ? $"{entregador.Nombre} {entregador.Apellidos}" : "Usuario no encontrado";
        }
        catch (Exception ex)
        {
            IdUsuarioGeneradorLabel.Text = $"Error: {ex.Message}";
            IdUsuarioQueEntregaLabel.Text = $"Error: {ex.Message}";
        }
    }
}