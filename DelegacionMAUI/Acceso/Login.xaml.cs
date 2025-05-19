using DelegacionMAUI.Servicio;
using DelegacionMAUI.Catalogo;

namespace DelegacionMAUI.Acceso;

public partial class Login : ContentPage
{
    private CiudadanoLoginServicio _servicio = new CiudadanoLoginServicio();

    public Login()
	{
		InitializeComponent();
        CargarCredencialesGuardadas();
    }

    private void CargarCredencialesGuardadas()
    {
        if (Preferences.Get("RecordarCredenciales", false))
        {
            emailEntry.Text = Preferences.Get("Email", string.Empty);
            passwordEntry.Text = Preferences.Get("Password", string.Empty);
            checkboxRecordarme.IsChecked = true;
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text?.Trim();
        string password = passwordEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            MostrarError("Ingresa correo y contraseña");
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
                // Guardar usuario en la sesión
                Sesion.UsuarioActual = usuario;

                // Guardar o eliminar credenciales según el checkbox
                if (checkboxRecordarme.IsChecked)
                {
                    Preferences.Set("Email", email);
                    Preferences.Set("Password", password);
                    Preferences.Set("RecordarCredenciales", true);
                }
                else
                {
                    Preferences.Remove("Email");
                    Preferences.Remove("Password");
                    Preferences.Remove("RecordarCredenciales");
                }

                await DisplayAlert("Bienvenido", $"Hola {usuario.Nombre} {usuario.Apellidos}", "OK");
                await Navigation.PushAsync(new HomePages());
            }
            else
            {
                MostrarError("Correo o contraseña incorrectos");
            }
        }
        catch (Exception ex)
        {
            MostrarError("Error de conexión. Intenta más tarde.");
        }
    }

    private void MostrarError(string mensaje)
    {
        errorLabel.Text = mensaje;
        errorLabel.IsVisible = true;
    }

    private async void OnAvisoTapped(object sender, EventArgs e)
    {
        await DisplayAlert("AVISO IMPORTANTE",
                          "El registro de nuevos usuarios es gestionado exclusivamente por el delegado oficial. " +
                          "Para obtener acceso a la aplicación, por favor acuda a la oficina del delegado para " +
                          "completar su registro.",
                          "Aceptar");
    }
}