using Amazon.DynamoDBv2.DataModel;

namespace Comision.API.Models;

[DynamoDBTable("VentaCore")]
public class Venta
{
    [DynamoDBHashKey("id")]
    public string ID_Venta { get; set; }
    
    [DynamoDBProperty]
    public string FechaVenta { get; set; }
    
    [DynamoDBProperty]
    public string ID_Vendedor { get; set; }
    
    [DynamoDBProperty]
    public decimal CuotaMonto { get; set; }
}