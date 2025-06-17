using Amazon.DynamoDBv2.DataModel;
using Comision.API.Models;
using Comision.API.Repository.Interfaces;

namespace Comision.API.Repository;

public class RulerRepository: IRepository<Regla>
{
    private readonly IDynamoDBContext _context;
    
    public RulerRepository(IDynamoDBContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Regla>> GetAllAsync()
    {
        var conditions = new List<ScanCondition>();
        var allRules = await _context.ScanAsync<Regla>(conditions).GetRemainingAsync();
        return allRules;
    }
    
    public async Task<Regla> GetByIdAsync(string id)
    {
        return await _context.LoadAsync<Regla>(id);
    }
    
    public async Task AddAsync(Regla regla)
    {
        regla.ID_Regla = Guid.NewGuid().ToString();
        await _context.SaveAsync(regla);
    }
    
    public async Task UpdateAsync(string id, Regla regla)
    {
        var existingRegla = await GetByIdAsync(id);
        if (existingRegla == null)
        {
            throw new Exception("Regla not found");
        }
        
        regla.ID_Regla = id;
        await _context.SaveAsync(regla);
    }
    
    public async Task DeleteAsync(string id)
    {
        var regla = await GetByIdAsync(id);
        if (regla == null)
        {
            throw new Exception("Regla not found");
        }
        
        await _context.DeleteAsync<Regla>(id);
    }
}