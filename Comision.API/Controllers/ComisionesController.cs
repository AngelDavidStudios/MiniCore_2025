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
    
    public ComisionesController(IVentaRepository ventaRepository, IRepository<Regla> reglaRepository)
    {
        _ventaRepository = ventaRepository;
        _reglaRepository = reglaRepository;
    }
    
    [HttpGet("Comisiones")]
    public async Task<IActionResult> GetComisiones([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
    {
        if (fechaInicio > fechaFin)
            return BadRequest("La fecha de inicio no puede ser mayor que la fecha final.");

        var ventas = await _ventaRepository.GetVentasByFechaAsync(fechaInicio, fechaFin);
        var reglas = (await _reglaRepository.GetAllAsync()).OrderBy(r => r.Amount).ToList();

        var resultado = new List<object>();

        foreach (var venta in ventas)
        {
            var regla = reglas.FirstOrDefault(r => venta.CuotaMonto <= r.Amount);
            if (regla != null)
            {
                var comision = venta.CuotaMonto * (decimal)regla.Rule;

                resultado.Add(new
                {
                    venta.ID_Venta,
                    venta.FechaVenta,
                    venta.CuotaMonto,
                    ReglaAplicada = regla.ID_Regla,
                    Porcentaje = regla.Rule,
                    Comision = Math.Round(comision, 2)
                });
            }
        }

        return Ok(resultado);
    }
}