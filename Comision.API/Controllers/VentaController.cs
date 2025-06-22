using Comision.API.Models;
using Comision.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comision.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentaController: ControllerBase
{
    private readonly IVentaRepository _ventaRepository;
    
    public VentaController(IVentaRepository ventaRepository)
    {
        _ventaRepository = ventaRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ventas = await _ventaRepository.GetVentasAsync();
        return Ok(ventas);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var venta = await _ventaRepository.GetVentaByIdAsync(id);
        if (venta == null)
        {
            return NotFound();
        }
        return Ok(venta);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Venta venta)
    {
        if (venta == null)
        {
            return BadRequest("Venta cannot be null");
        }
        
        await _ventaRepository.AddVentaAsync(venta);
        return CreatedAtAction(nameof(Get), new { id = venta.ID_Venta }, venta);
    }
    
    /*
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] Venta venta)
    {
        if (venta == null || string.IsNullOrEmpty(id))
        {
            return BadRequest("Invalid data");
        }
        
        await _ventaRepository.UpdateVentaAsync(id, venta);
        return NoContent();
    }
    */
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Invalid ID");
        }
        
        await _ventaRepository.DeleteVentaAsync(id);
        return NoContent();
    }
}