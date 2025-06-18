using Comision.API.Models;
using Comision.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comision.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComisionesController: ControllerBase
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IRepository<Regla> _reglaRepository;
    private readonly IRepository<Vendedor> _vendedorRepository;
    
    public ComisionesController(IVentaRepository ventaRepository, IRepository<Regla> reglaRepository, IRepository<Vendedor> vendedorRepository)
    {
        _ventaRepository = ventaRepository;
        _reglaRepository = reglaRepository;
        _vendedorRepository = vendedorRepository;
    }
    
    [HttpGet("Comisiones")]
    public async Task<IActionResult> GetComisiones([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
    {
        if (fechaInicio > fechaFin)
            return BadRequest("La fecha de inicio no puede ser mayor que la fecha final.");

        var ventas = await _ventaRepository.GetVentasByFechaAsync(fechaInicio, fechaFin);
        var reglas = (await _reglaRepository.GetAllAsync()).OrderByDescending(r => r.Amount).ToList();
        var vendedores = await _vendedorRepository.GetAllAsync();

        // Agrupar las ventas por ID_Vendedor
        var agrupadasPorVendedor = ventas
            .GroupBy(v => v.ID_Vendedor)
            .Select(g => new
            {
                ID_Vendedor = g.Key,
                TotalVentas = g.Sum(v => v.CuotaMonto)
            })
            .ToList();

        var resultado = new List<object>();

        foreach (var vendedor in agrupadasPorVendedor)
        {
            // Buscar la primera regla que cubra el monto total
            var regla = reglas.FirstOrDefault(r => vendedor.TotalVentas >= r.Amount);
            var nombre = vendedores.FirstOrDefault(v => v.ID_Vendedor == vendedor.ID_Vendedor)?.Nombre ?? "Desconocido";
            
            if (regla != null)
            {
                var comision = vendedor.TotalVentas * (decimal)regla.Rule;

                resultado.Add(new
                {
                    vendedor.ID_Vendedor,
                    Nombre = nombre,
                    TotalVentas = vendedor.TotalVentas,
                    ReglaAplicada = regla.ID_Regla,
                    Porcentaje = regla.Rule,
                    Comision = Math.Round(comision, 2)
                });
            }
            else
            {
                // Si no hay regla aplicable, opcionalmente puedes incluir el vendedor con 0 comisión
                resultado.Add(new
                {
                    vendedor.ID_Vendedor,
                    Nombre = nombre,
                    TotalVentas = vendedor.TotalVentas,
                    ReglaAplicada = "Ninguna",
                    Porcentaje = 0,
                    Comision = 0
                });
            }
        }

        return Ok(resultado);
    }
}