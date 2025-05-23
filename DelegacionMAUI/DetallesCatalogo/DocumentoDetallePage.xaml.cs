using DelegacionMAUI.Acceso;
using DelegacionMAUI.Modelo;
using DelegacionMAUI.Servicio;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class DocumentoDetallePage : ContentPage
{
    private string correoDelegacion; // Variable para guardar el correo dinámico
    private Documento documentoActual; // Para almacenar el documento recibido

    public DocumentoDetallePage( Documento documento)
	{
		InitializeComponent();

        documentoActual = documento;

        // Asignar el documento al contexto de datos para que funcione el Binding en XAML
        BindingContext = documento;

        IdDocumentoLabel.Text = documento.Nombre;
        CostoLabel.Text = documento.Costo.ToString("C");
        notasLabel.Text = documento.Notas;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var servicio = new InfoDelegacionServicio();
            var info = await servicio.IInfoDelegacion();

            if (info != null && info.Any())
            {
                // Acceder al modelo correcto que sí tiene "Correo"
                correoDelegacion = info.First().Correo;
            }
            else
            {
                await DisplayAlert("Aviso", "No se encontró información de la delegación.", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo obtener la información de la delegación: " + ex.Message, "Aceptar");
        }
    }

    private async void OnSolicitarDocumentoClicked(object sender, EventArgs e)
    {
        try
        {
            // Obtener el usuario actual de la sesión
            var usuario = Sesion.UsuarioActual;

            if (usuario == null)
            {
                await DisplayAlert("Error", "No hay un usuario autenticado.", "Aceptar");
                return;
            }

            // Validar si se cargó correctamente el correo de la delegación
            if (string.IsNullOrEmpty(correoDelegacion))
            {
                await DisplayAlert("Error", "No se pudo obtener el correo de la delegación.", "Aceptar");
                return;
            }

            // Crear el asunto y cuerpo del correo
            string subject = Uri.EscapeDataString($"Solicitud de documento: {documentoActual.Nombre}");

            string body = Uri.EscapeDataString(
                $"Solicito el documento: {documentoActual.Nombre}\n" +
                $"Costo: {documentoActual.Costo:C}\n\n" +
                $"Datos del solicitante:\n" +
                $"Nombre: {usuario.Nombre} {usuario.Apellidos}\n" +
                $"Correo: {usuario.Email}\n\n" +
                $"Favor de proporcionarme información sobre cómo proceder con este trámite.\n\nGracias."
            );

            string uri = $"mailto:{correoDelegacion}?subject={subject}&body={body}";

            // Confirmar con el usuario antes de enviar
            bool confirmar = await DisplayAlert("Confirmar", $"¿Deseas enviar un correo a {correoDelegacion}?", "Sí", "No");
            if (!confirmar) return;

            // Abrir el cliente de correo
            await Launcher.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir la aplicación de correo. " + ex.Message, "Aceptar");
        }
    }
}