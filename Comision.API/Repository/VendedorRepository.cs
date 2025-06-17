using Amazon.DynamoDBv2.DataModel;
using Comision.API.Models;
using Comision.API.Repository.Interfaces;

namespace Comision.API.Repository;

public class VendedorRepository: IRepository<Vendedor>
{
    private readonly IDynamoDBContext _context;
    
    public VendedorRepository(IDynamoDBContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Vendedor>> GetAllAsync()
    {
        var conditions = new List<ScanCondition>();
        var allVendedores = await _context.ScanAsync<Vendedor>(conditions).GetRemainingAsync();
        return allVendedores;
    }
    
    public async Task<Vendedor> GetByIdAsync(string id)
    {
        return await _context.LoadAsync<Vendedor>(id);
    }
    
    public async Task AddAsync(Vendedor vendedor)
    {
        vendedor.ID_Vendedor = Guid.NewGuid().ToString();
        await _context.SaveAsync(vendedor);
    }
    
    public async Task UpdateAsync(string id, Vendedor vendedor)
    {
        var existingVendedor = await GetByIdAsync(id);
        if (existingVendedor == null)
        {
            throw new Exception("Vendedor not found");
        }
        
        vendedor.ID_Vendedor = id;
        await _context.SaveAsync(vendedor);
    }
    
    public async Task DeleteAsync(string id)
    {
        var vendedor = await GetByIdAsync(id);
        if (vendedor == null)
        {
            throw new Exception("Vendedor not found");
        }
        
        await _context.DeleteAsync<Vendedor>(id);
    }
}