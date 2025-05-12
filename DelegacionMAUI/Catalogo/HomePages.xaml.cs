namespace DelegacionMAUI.Catalogo;

public partial class HomePages : ContentPage
{
	public HomePages()
	{
		InitializeComponent();
	}

    private async void OnAvisoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AvisoPages());
    }

    private async void OnDocumentoSolicitadoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DocumentoSolicitadoPages());
    }

    private async void OnDocumentoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DocumentoPages());
    }

    private async void OnCooperacionesDeCiudadanoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CooperacionesDeCiudadanoPages());
    }

    private async void OnCooperacionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CooperacionPages());
    }
}