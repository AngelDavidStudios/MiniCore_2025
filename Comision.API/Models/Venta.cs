namespace Comision.API.Models;

public class Venta
{
    public string ID_Venta { get; set; }
    public string FechaVenta { get; set; }
    public string ID_Vendedor { get; set; }
    public decimal CuotaMonto { get; set; }
}