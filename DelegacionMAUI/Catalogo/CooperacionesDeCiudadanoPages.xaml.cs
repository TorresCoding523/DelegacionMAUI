using DelegacionMAUI.Acceso;
using DelegacionMAUI.DetallesCatalogo;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.Catalogo;

public partial class CooperacionesDeCiudadanoPages : ContentPage
{
    private CooperacionesDeCiudadanoServicio cooperacionesDeCiudadanoServicio = new CooperacionesDeCiudadanoServicio();
    private List<CooperacionesDeCiudadano> _cooperacionesDeCiudadanoOriginales = new();

    public CooperacionesDeCiudadanoPages()
	{
		InitializeComponent();
        CargarCooperacionesDeCiudadano();
    }

    private async void CargarCooperacionesDeCiudadano()
    {
        try
        {
            var todasLasCooperaciones = await cooperacionesDeCiudadanoServicio.GetCooperacionesDeCiudadanoAsync();

            // Filtra las cooperaciones del usuario actual
            var idUsuarioActual = Sesion.UsuarioActual.IdCiudadano; // Suponiendo que este es el mismo que IdCiudadano
            var cooperacionesDelUsuario = todasLasCooperaciones
                .Where(c => c.IdCiudadano == idUsuarioActual)
                .ToList();

            _cooperacionesDeCiudadanoOriginales = cooperacionesDelUsuario;
            cooperacionesCollectionView.ItemsSource = _cooperacionesDeCiudadanoOriginales;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar las Cooperaciones: " + ex.Message, "OK");
        }
    }

    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is CooperacionesDeCiudadano cooperacionesDeCiudadano)
        {
            await Navigation.PushAsync(new CooperacionesDeCiudadanoDetallePages(cooperacionesDeCiudadano));
        }
    }
}