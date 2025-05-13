using DelegacionMAUI.Acceso;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class CooperacionesDeCiudadanoDetallePages : ContentPage
{
    private readonly CooperacionesDeCiudadano _cooperacionCiudadano;
    private readonly CooperacionServicio _cooperacionServicio = new();

    public CooperacionesDeCiudadanoDetallePages(CooperacionesDeCiudadano cooperacion)
	{
		InitializeComponent();
        _cooperacionCiudadano = cooperacion;
        _ = MostrarDetallesAsync(); // Llamada asíncrona
    }
    private async Task MostrarDetallesAsync()
    {
        //Mostrar nombre completo desde la sesión
        if (Sesion.UsuarioActual != null)
        {
            idCiudadanoLabel.Text = $"Ciudadano: {Sesion.UsuarioActual.Nombre} {Sesion.UsuarioActual.Apellidos}";
        }
        else
        {
            idCiudadanoLabel.Text = "Ciudadano no identificado";
        }

        fechaPagoLabel.Text = $" {_cooperacionCiudadano.FechaDePago:dd/MM/yyyy}";
        esParcialLabel.Text = _cooperacionCiudadano.EsParcial ? " Sí" : " No";
        notasLabel.Text = $" {_cooperacionCiudadano.Notas}";

        try
        {
            var cooperacion = await _cooperacionServicio.ObtenerCooperacionPorIdAsync(_cooperacionCiudadano.IdCooperacion);

            if (cooperacion != null)
            {
                idCooperacionLabel.Text = $"{cooperacion.Nombre}\n{cooperacion.Descripcion}";
            }
            else
            {
                idCooperacionLabel.Text = "Información de cooperación no disponible";
            }
        }
        catch (Exception ex)
        {
            idCooperacionLabel.Text = $"Error al obtener cooperación: {ex.Message}";
        }
    }
}