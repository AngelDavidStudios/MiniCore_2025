using Comision.API.Models;

namespace Comision.API.Repository.Interfaces;

public interface IVentaRepository
{
    Task<IEnumerable<Venta>> GetVentasAsync();
    Task<Venta> GetVentaByIdAsync(string id);
    Task AddVentaAsync(Venta venta);
    Task UpdateVentaAsync(string id, Venta venta);
    Task DeleteVentaAsync(string id);
    
    // Filtro por fecha
    Task<IEnumerable<Venta>> GetVentasByFechaAsync(DateTime fechaInicio, DateTime fechaFin);

}