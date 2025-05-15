using DelegacionMAUI.DetallesCatalogo;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.Catalogo;

public partial class CooperacionPages : ContentPage
{
    private readonly CooperacionServicio cooperacionServicio;

    public CooperacionPages()
	{
		InitializeComponent();
        cooperacionServicio = new CooperacionServicio();
        CargarCooperaciones();
    }

    private async void CargarCooperaciones()
    {
        try
        {
            var lista = await cooperacionServicio.GetCooperacionAsync();
            cooperacionesCollectionView.ItemsSource = lista;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar las cooperaciones: " + ex.Message, "OK");
        }
    }

    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Cooperacion cooperacion)
        {
            await Navigation.PushAsync(new CooperacionDetallesPage(cooperacion));
        }
    }
}