using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Comision.API.Models;
using Comision.API.Repository.Interfaces;

namespace Comision.API.Repository;

public class VentaRepository: IVentaRepository
{
    private readonly DynamoDBContext _context;
    
    public VentaRepository(DynamoDBContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Venta>> GetVentasAsync()
    {
        return await _context.ScanAsync<Venta>(new List<ScanCondition>()).GetRemainingAsync();
    }
    public async Task<Venta> GetVentaByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        return await _context.LoadAsync<Venta>(id);
    }
    
    public async Task AddVentaAsync(Venta venta)
    {
        if (venta == null)
        {
            throw new ArgumentNullException(nameof(venta));
        }
        
        await _context.SaveAsync(venta);
    }
    
    public async Task UpdateVentaAsync(string id, Venta venta)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        if (venta == null)
        {
            throw new ArgumentNullException(nameof(venta));
        }
        
        venta.ID_Venta = id;
        await _context.SaveAsync(venta);
    }
    
    public async Task DeleteVentaAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        var venta = await GetVentaByIdAsync(id);
        if (venta == null)
        {
            throw new Exception("Venta not found");
        }
        
        await _context.DeleteAsync(venta);
    }
    
    public async Task<IEnumerable<Venta>> GetVentasByFechaAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        if (fechaInicio > fechaFin)
            throw new ArgumentException("Fecha de inicio no puede ser mayor que la fecha de fin");

        var fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
        var fechaFinStr = fechaFin.ToString("yyyy-MM-dd");

        var conditions = new List<ScanCondition>
        {
            new ScanCondition(nameof(Venta.FechaVenta), ScanOperator.Between, fechaInicioStr, fechaFinStr)
        };

        return await _context.ScanAsync<Venta>(conditions).GetRemainingAsync();
    }

    
}