using Comision.API.Models;
using Comision.API.Repository.Interfaces;
using Comision.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comision.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComisionesController: ControllerBase
{
    
    private readonly IComisionService _comisionService;
    
    public ComisionesController(IComisionService comisionService)
    {
        _comisionService = comisionService;
    }
    
    [HttpGet("Comisiones")]
    public async Task<IActionResult> GetComisiones([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
    {
        if (fechaInicio > fechaFin)
            return BadRequest("La fecha de inicio no puede ser mayor que la fecha final.");

        var resultado = await _comisionService.CalcularComisionesAsync(fechaInicio, fechaFin);
        return Ok(resultado);
    }
}