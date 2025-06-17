using Amazon.DynamoDBv2.DataModel;

namespace Comision.API.Models;

[DynamoDBTable("VendedorCore")]
public class Vendedor
{
    [DynamoDBHashKey("id")]
    public string ID_Vendedor { get; set; }
    
    [DynamoDBProperty]
    public string Nombre { get; set; }
}