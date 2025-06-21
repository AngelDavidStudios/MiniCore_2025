using Comision.API.Models;
using Comision.API.Repository.Interfaces;
using Comision.API.Services.DTOs;
using Comision.API.Services.Interfaces;

namespace Comision.API.Services;

public class ComisionService : IComisionService
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IRepository<Regla> _reglaRepository;
    private readonly IRepository<Vendedor> _vendedorRepository;
    
    public ComisionService(IVentaRepository ventaRepository, IRepository<Regla> reglaRepository, IRepository<Vendedor> vendedorRepository)
    {
        _ventaRepository = ventaRepository;
        _reglaRepository = reglaRepository;
        _vendedorRepository = vendedorRepository;
    }
    
    public async Task<IEnumerable<ComisionResultadoDto>> CalcularComisionesAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        var ventas = await _ventaRepository.GetVentasByFechaAsync(fechaInicio, fechaFin);
        var reglas = (await _reglaRepository.GetAllAsync()).OrderByDescending(r => r.Amount).ToList();
        var vendedores = await _vendedorRepository.GetAllAsync();

        var agrupadasPorVendedor = ventas
            .GroupBy(v => v.ID_Vendedor)
            .Select(g => new
            {
                ID_Vendedor = g.Key,
                TotalVentas = g.Sum(v => v.CuotaMonto)
            });

        var resultado = new List<ComisionResultadoDto>();

        foreach (var v in agrupadasPorVendedor)
        {
            var regla = reglas.FirstOrDefault(r => v.TotalVentas >= r.Amount);
            var nombre = vendedores.FirstOrDefault(x => x.ID_Vendedor == v.ID_Vendedor)?.Nombre ?? "Desconocido";

            var dto = new ComisionResultadoDto
            {
                ID_Vendedor = v.ID_Vendedor,
                Nombre = nombre,
                TotalVentas = v.TotalVentas,
                ReglaAplicada = regla?.ID_Regla ?? "Ninguna",
                Porcentaje = regla?.Rule ?? 0,
                Comision = regla != null ? Math.Round(v.TotalVentas * (decimal)regla.Rule, 2) : 0
            };

            resultado.Add(dto);
        }
        return resultado;
    }
}