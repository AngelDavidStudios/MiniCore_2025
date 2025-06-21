namespace Comision.API.Services.DTOs;

public class ComisionResultadoDto
{
    public string ID_Vendedor { get; set; }
    public string Nombre { get; set; }
    public decimal TotalVentas { get; set; }
    public object ReglaAplicada { get; set; }
    public double Porcentaje { get; set; }
    public decimal Comision { get; set; }
}