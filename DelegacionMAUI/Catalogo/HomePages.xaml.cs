namespace DelegacionMAUI.Catalogo;

public partial class HomePages : ContentPage
{
	public HomePages()
	{
		InitializeComponent();
	}

    private async void OnAvisoClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Catalogo.AvisoPages());
    }

    private async void OnDocumentoSolicitadoClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Catalogo.DocumentoSolicitadoPages());
    }

    private async void OnDocumentoClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Catalogo.DocumentoPages());
    }

    private async void OnCooperacionesDeCiudadanoClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Catalogo.CooperacionesDeCiudadanoPages());
    }

    private async void OnCooperacionClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Catalogo.CooperacionPages());
    }

    private async void OnAtencionCiudadanaClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Catalogo.AtencionAlClientePages());
    }
}