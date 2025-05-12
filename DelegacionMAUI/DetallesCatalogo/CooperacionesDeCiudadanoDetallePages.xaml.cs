using DelegacionMAUI.Modelo;

namespace DelegacionMAUI.DetallesCatalogo;

public partial class CooperacionesDeCiudadanoDetallePages : ContentPage
{
    private CooperacionesDeCiudadano _cooperacion;

    public CooperacionesDeCiudadanoDetallePages(CooperacionesDeCiudadano cooperacion)
	{
		InitializeComponent();
        _cooperacion = cooperacion;
        MostrarDetalles();
    }
    private void MostrarDetalles()
    {
        idCiudadanoLabel.Text = $"ID Ciudadano: {_cooperacion.IdCiudadano}";
        idCooperacionLabel.Text = $"ID Cooperacion: {_cooperacion.IdCooperacion}";
        fechaPagoLabel.Text = $"Fecha de Pago: {_cooperacion.FechaDePago:dd/MM/yyyy}";
        esParcialLabel.Text = _cooperacion.EsParcial ? "Pago Parcial: Sí" : "Pago Parcial: No";
        notasLabel.Text = $"Notas: {_cooperacion.Notas}";
    }
}