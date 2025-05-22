using DelegacionMAUI.Acceso;
using DelegacionMAUI.Modelo;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class DocumentoDetallePage : ContentPage
{
	public DocumentoDetallePage( Documento documento)
	{
		InitializeComponent();

        // Asignar el documento al contexto de datos para que funcione el Binding en XAML
        BindingContext = documento;

        IdDocumentoLabel.Text = documento.Nombre;
        CostoLabel.Text = documento.Costo.ToString("C");
        notasLabel.Text = documento.Notas;
    }

    private async void OnSolicitarDocumentoClicked(object sender, EventArgs e)
    {
        try
        {
            // Obtener el documento actual
            var button = (Button)sender;
            var documento = (Documento)button.CommandParameter;

            // Obtener el usuario actual de la sesión
            var usuario = Sesion.UsuarioActual;

            if (usuario == null)
            {
                await DisplayAlert("Error", "No hay un usuario autenticado.", "Aceptar");
                return;
            }

            // Crear la URI de correo
            string recipient = "05angelt@gmail.com"; // Destinatario fijo (quien recibe la solicitud)
            string subject = Uri.EscapeDataString($"Solicitud de documento: {documento.Nombre}");

            // Incluir datos del usuario que solicita
            string body = Uri.EscapeDataString(
                $"Solicito el documento: {documento.Nombre}\n" +
                $"Costo: {documento.Costo:C}\n\n" +
                $"Datos del solicitante:\n" +
                $"Nombre: {usuario.Nombre} {usuario.Apellidos}\n" +
                $"Correo: {usuario.Email}\n\n" +
                $"Favor de proporcionarme información sobre cómo proceder con este trámite.\n\nGracias."
            );

            string uri = $"mailto:{recipient}?subject={subject}&body={body}";

            // Abrir el cliente de correo
            await Launcher.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir la aplicación de correo. " + ex.Message, "Aceptar");
        }
    }
}