using DelegacionMAUI.Modelo;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class CooperacionDetallesPage : ContentPage
{
	public CooperacionDetallesPage(Cooperacion cooperacion)
	{
		InitializeComponent();
        IdCooperacionLabel.Text = cooperacion.Nombre;
        DescripcionLabel.Text = cooperacion.Descripcion;
        MontoLabel.Text = cooperacion.Monto.ToString("C");
        FechaDeInicioLabel.Text = $"Fecha: {cooperacion.FechaDeInicio:dd/MM/yyyy}";
        FechaLimiteDePagoLabel.Text = $"Fecha: {cooperacion.FechaLimiteDePago:dd/MM/yyyy}";
    }
}