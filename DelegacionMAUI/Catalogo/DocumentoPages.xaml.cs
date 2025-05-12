using DelegacionMAUI.Acceso;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.Catalogo;

public partial class DocumentoPages : ContentPage
{
    private DocumentoServicio documentoServicio = new DocumentoServicio();
    private List<Documento> _documentoOriginales = new();

    public DocumentoPages()
	{
		InitializeComponent();
        // Opcional: establecer valores por defecto
        SearchBar.Text = "";
        OrderPicker.SelectedIndex = 0; // Por defecto: Fecha (más reciente)
        CargarDocumentos();
    }

    private async void CargarDocumentos()
    {
        try
        {
            var documentos = await documentoServicio.GetDocumentoAsync();
            _documentoOriginales = documentos;
            AplicarFiltrosYOrden();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar los documentos: " + ex.Message, "OK");
        }
    }

    private void AplicarFiltrosYOrden()
    {
        IEnumerable<Documento> documentoFiltrados = _documentoOriginales;

        string textoBusqueda = SearchBar.Text?.ToLower() ?? "";
        if (!string.IsNullOrWhiteSpace(textoBusqueda))
        {
            documentoFiltrados = documentoFiltrados.Where(a =>
                (a.Nombre?.ToLower().Contains(textoBusqueda) ?? false));
        }

        switch (OrderPicker.SelectedIndex)
        {
            case 0: documentoFiltrados = documentoFiltrados.OrderByDescending(a => a.Costo); break;
            case 1: documentoFiltrados = documentoFiltrados.OrderBy(a => a.Costo); break;
            case 2: documentoFiltrados = documentoFiltrados.OrderBy(a => a.Nombre); break;
            case 3: documentoFiltrados = documentoFiltrados.OrderByDescending(a => a.Nombre); break;
        }

        documentosCollectionView.ItemsSource = documentoFiltrados.ToList();
    }

    private async void OnDocumentoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        var documentoSeleccionado = e.CurrentSelection.FirstOrDefault() as Documento;
        if (documentoSeleccionado == null)
            return;

        string mensaje = $"Nombre: {documentoSeleccionado.Nombre}\n" +
                         $"Costo: {documentoSeleccionado.Costo:C}\n" +
                         $"Notas: {documentoSeleccionado.Notas}\n" +
                         $"Plantilla URL: {documentoSeleccionado.URLPlantilla}";

        await DisplayAlert("Detalles del Documento", mensaje, "Cerrar");
        ((CollectionView)sender).SelectedItem = null;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        AplicarFiltrosYOrden();
    }

    private void OnOrderChanged(object sender, EventArgs e)
    {
        AplicarFiltrosYOrden();
    }

    private async void OnSolicitarDocumentoClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var documento = (Documento)button.CommandParameter;

        var documentoSolicitado = new DocumentoSolicitado
        {
            IdDocumento = documento.IdDocumento,
            IdCiudadanoSolicitante = Sesion.UsuarioActual.IdCiudadano, // Usuario logueado
            FechaSolicitud = DateTime.Now,
            FechaEntrega = null,
            IdUsuarioGenerador = "admin", // Quien genera la solicitud (ajústalo si es necesario)
            FechaPago = null,
            MontoPagado = documento.Costo,
            IdUsuarioQueEntrega = null,
            Finalidad = "Trámite personal",
            Notas = "Solicitado desde app móvil"
        };

        var servicioSolicitado = new DocumentoSolicitadoServicio();
        bool exito = await servicioSolicitado.SolicitarDocumentoAsync(documentoSolicitado);

        if (exito)
            await DisplayAlert("Éxito", "El documento fue solicitado correctamente.", "OK");
        else
            await DisplayAlert("Error", "Hubo un problema al solicitar el documento.", "OK");
    }
}