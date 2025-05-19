using DelegacionMAUI.DetallesCatalogo;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.Catalogo;

public partial class DocumentoSolicitadoPages : ContentPage
{
    private DocumentoSolicitadoServicio documentoSolicitadoServicio = new DocumentoSolicitadoServicio();
    private DocumentoServicio documentoServicio = new DocumentoServicio(); // Añade esto

    public DocumentoSolicitadoPages()
	{
		InitializeComponent();
        CargarDocumentosSolicitados();
    }

    private async void CargarDocumentosSolicitados()
    {
        try
        {
            // Traer documentos y documentos solicitados
            var documentos = await documentoServicio.GetDocumentoAsync();
            var documentosSolicitados = await documentoSolicitadoServicio.GetDocumentoSolicitadoAsync();

            // Asignar el nombre del documento a cada DocumentoSolicitado
            foreach (var docSol in documentosSolicitados)
            {
                var documentoRelacionado = documentos.FirstOrDefault(d => d.IdDocumento == docSol.IdDocumento);
                if (documentoRelacionado != null)
                {
                    docSol.NombreDocumento = documentoRelacionado.Nombre;
                }
            }

            documentosSolicitadosCollectionView.ItemsSource = documentosSolicitados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar los documentos solicitados: " + ex.Message, "OK");
        }
    }

    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is DocumentoSolicitado documentoSolicitado)
        {
            await Navigation.PushAsync(new DocumentoSolicitadoDetallePages(documentoSolicitado));
        }
    }
}