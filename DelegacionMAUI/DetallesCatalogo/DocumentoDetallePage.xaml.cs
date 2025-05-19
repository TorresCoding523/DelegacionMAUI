using DelegacionMAUI.Modelo;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class DocumentoDetallePage : ContentPage
{
	public DocumentoDetallePage( Documento documento)
	{
		InitializeComponent();
        IdDocumentoLabel.Text = documento.Nombre;
        CostoLabel.Text = documento.Costo.ToString("C");
        notasLabel.Text = documento.Notas;
    }

    private void OnSolicitarDocumentoClicked(object sender, EventArgs e)
    {

    }
}