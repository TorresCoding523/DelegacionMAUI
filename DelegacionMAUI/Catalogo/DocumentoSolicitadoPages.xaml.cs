using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.Catalogo;

public partial class DocumentoSolicitadoPages : ContentPage
{
    private DocumentoSolicitadoServicio documentoSolicitadoServicio = new DocumentoSolicitadoServicio();
    public DocumentoSolicitadoPages()
	{
		InitializeComponent();
        CargarDocumentosSolicitados();
    }

    private async void CargarDocumentosSolicitados()
    {
        try
        {
            var documentosSolicitados = await documentoSolicitadoServicio.GetDocumentoSolicitadoAsync();
            documentosSolicitadosCollectionView.ItemsSource = documentosSolicitados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar los documentos solicitados: " + ex.Message, "OK");
        }
    }
}