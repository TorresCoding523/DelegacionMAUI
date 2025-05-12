using DelegacionMAUI.Modelo;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class AvisoDetallePage : ContentPage
{
	public AvisoDetallePage(Aviso aviso)
	{
		InitializeComponent();
        TituloLabel.Text = aviso.Titulo;
        FechaLabel.Text = $"Fecha: {aviso.Fecha:dd/MM/yyyy}";
        TextoLabel.Text = aviso.Texto;
    }
}