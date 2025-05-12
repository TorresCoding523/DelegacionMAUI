using DelegacionMAUI.Servicio;
using DelegacionMAUI.Catalogo;

namespace DelegacionMAUI.Acceso;

public partial class Login : ContentPage
{
    private CiudadanoLoginServicio _servicio = new CiudadanoLoginServicio();

    public Login()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text?.Trim();
        string password = passwordEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            MostrarError("Ingresa correo y contrase�a");
            return;
        }

        try
        {
            var usuarios = await _servicio.GetUsuariosAsync();

            var usuario = usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (usuario != null)
            {
                // Guardar usuario en la sesi�n
                Sesion.UsuarioActual = usuario;

                await DisplayAlert("Bienvenido", $"Hola {usuario.Nombre} {usuario.Apellidos}", "OK");
                await Navigation.PushAsync(new HomePages());
            }
            else
            {
                MostrarError("Correo o contrase�a incorrectos");
            }
        }
        catch (Exception ex)
        {
            MostrarError("Error de conexi�n. Intenta m�s tarde.");
        }
    }

    private void MostrarError(string mensaje)
    {
        errorLabel.Text = mensaje;
        errorLabel.IsVisible = true;
    }
}