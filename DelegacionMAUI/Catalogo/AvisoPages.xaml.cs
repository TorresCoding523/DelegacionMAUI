using DelegacionMAUI.DetallesCatalogo;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;
using System.Collections.ObjectModel;

namespace DelegacionMAUI.Catalogo;

public partial class AvisoPages : ContentPage
{
    private readonly AvisoServicio _avisoServicio = new();
    private List<Aviso> _avisosOriginales = new();

    public AvisoPages()
    {
        InitializeComponent();
        // Opcional: establecer valores por defecto
        SearchBar.Text = "";
        OrderPicker.SelectedIndex = 0; // Por defecto: Fecha (más reciente)
        CargarAvisos();
    }

    private async void CargarAvisos()
    {
        try
        {
            var avisos = await _avisoServicio.GetAvisoAsync();
            _avisosOriginales = avisos; // Guardamos la lista original completa
            AplicarFiltrosYOrden(); // Mostramos en pantalla
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar los avisos.\n" + ex.Message, "OK");
        }
    }

    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Aviso aviso)
        {
            //await Navigation.PushAsync(new AvisoDetallePage(aviso));
            await Navigation.PushModalAsync(new DetallesCatalogo.AvisoDetallePage(aviso));
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        AplicarFiltrosYOrden();
    }

    private void OnOrderChanged(object sender, EventArgs e)
    {
        AplicarFiltrosYOrden();
    }

    private void AplicarFiltrosYOrden()
    {
        IEnumerable<Aviso> avisosFiltrados = _avisosOriginales;

        // Filtro de búsqueda
        string textoBusqueda = SearchBar.Text?.ToLower() ?? "";
        if (!string.IsNullOrWhiteSpace(textoBusqueda))
        {
            avisosFiltrados = avisosFiltrados.Where(a =>
                (a.Titulo?.ToLower().Contains(textoBusqueda) ?? false));
        }

        // Ordenamiento
        switch (OrderPicker.SelectedIndex)
        {
            case 0: // Fecha (más reciente)
                avisosFiltrados = avisosFiltrados.OrderByDescending(a => a.Fecha);
                break;
            case 1: // Fecha (más antigua)
                avisosFiltrados = avisosFiltrados.OrderBy(a => a.Fecha);
                break;
            case 2: // Título (A-Z)
                avisosFiltrados = avisosFiltrados.OrderBy(a => a.Titulo);
                break;
            case 3: // Título (Z-A)
                avisosFiltrados = avisosFiltrados.OrderByDescending(a => a.Titulo);
                break;
        }

        // Mostrar resultado
        AvisosCollectionView.ItemsSource = avisosFiltrados.ToList();
    }
}