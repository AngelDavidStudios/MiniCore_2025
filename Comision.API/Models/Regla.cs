using Amazon.DynamoDBv2.DataModel;

namespace Comision.API.Models;

[DynamoDBTable("RulerCore")]
public class Regla
{
    [DynamoDBHashKey("id")]
    public string ID_Regla { get; set; }
    
    [DynamoDBProperty]
    public double Rule { get; set; }
    
    [DynamoDBProperty]
    public decimal Amount { get; set; }
}