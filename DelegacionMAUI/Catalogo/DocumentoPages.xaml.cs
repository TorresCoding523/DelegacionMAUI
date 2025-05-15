using DelegacionMAUI.Acceso;
using DelegacionMAUI.DetallesCatalogo;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;
using System.Collections.ObjectModel;

namespace DelegacionMAUI.Catalogo;

public partial class DocumentoPages : ContentPage
{
    private DocumentoServicio documentoServicio = new DocumentoServicio();
    private ObservableCollection<Documento> documentosCollection = new ObservableCollection<Documento>();
    private List<Documento> documentosOriginales = new List<Documento>();

    public DocumentoPages()
	{
		InitializeComponent();
        CargarDocumentos();
    }

    private async void CargarDocumentos()
    {
        try
        {
            documentosOriginales = await documentoServicio.GetDocumentoAsync();
            documentosCollection = new ObservableCollection<Documento>(documentosOriginales);
            documentosCollectionView.ItemsSource = documentosCollection;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar los documentos: " + ex.Message, "OK");
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = SearchBar.Text?.ToLower() ?? "";

        if (string.IsNullOrWhiteSpace(searchText))
        {
            documentosCollectionView.ItemsSource = new ObservableCollection<Documento>(documentosOriginales);
        }
        else
        {
            var filteredItems = documentosOriginales
                .Where(doc => doc.Nombre.ToLower().Contains(searchText))
                .ToList();

            documentosCollectionView.ItemsSource = new ObservableCollection<Documento>(filteredItems);
        }
    }

    private void OnOrderChanged(object sender, EventArgs e)
    {
        if (documentosOriginales == null || !documentosOriginales.Any()) return;

        var items = documentosOriginales.ToList();

        switch (OrderPicker.SelectedIndex)
        {
            case 0: // Costo (Mayor precio)
                items = items.OrderByDescending(d => d.Costo).ToList();
                break;
            case 1: // Costo (Menor precio)
                items = items.OrderBy(d => d.Costo).ToList();
                break;
            case 2: // Nombre (A-Z)
                items = items.OrderBy(d => d.Nombre).ToList();
                break;
            case 3: // Nombre (Z-A)
                items = items.OrderByDescending(d => d.Nombre).ToList();
                break;
        }
        documentosCollectionView.ItemsSource = new ObservableCollection<Documento>(items);
    }

    private void OnDocumentoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Documento documento)
        {
            // Aquí puedes implementar alguna acción cuando se selecciona un documento
            documentosCollectionView.SelectedItem = null;
        }
    }

    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Documento documentoSeleccionado)
        {
            await Navigation.PushAsync(new DocumentoDetallePage(documentoSeleccionado));
        }
    }
}