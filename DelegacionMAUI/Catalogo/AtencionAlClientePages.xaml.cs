using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.Catalogo;

public partial class AtencionAlClientePages : ContentPage
{
    private readonly InfoDelegacionServicio _servicio;

    public AtencionAlClientePages()
	{
		InitializeComponent();
        _servicio = new InfoDelegacionServicio();
        CargarDelegaciones(); // Llama al método al iniciar
    }

    private async void CargarDelegaciones()
    {
        try
        {
            var datos = await _servicio.IInfoDelegacion();

            if (datos != null && datos.Count > 0)
            {
                var delegacion = datos[0];

                NombreLabel.Text = delegacion.Nombre;
                DescripcionLabel.Text = delegacion.Descripcion;
                DireccionLabel.Text = delegacion.Direccion;
                TelefonoLabel.Text = delegacion.Telefono;
                CorreoLabel.Text = delegacion.Correo;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo cargar la información: " + ex.Message, "Aceptar");
        }
    }

    private async void OnCopyTelefonoClicked(object sender, EventArgs e)
    {
        var text = TelefonoLabel.Text;

        if (!string.IsNullOrWhiteSpace(text))
        {
            await Clipboard.SetTextAsync(text);
            await DisplayAlert("Copiado", "Copiado al portapapeles", "OK");
        }
    }
}