using Comision.API.Models;
using Comision.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comision.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendedorController: ControllerBase
{
    private readonly IRepository<Vendedor> _vendedorRepository;
    
    public VendedorController(IRepository<Vendedor> vendedorRepository)
    {
        _vendedorRepository = vendedorRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var vendedores = await _vendedorRepository.GetAllAsync();
        return Ok(vendedores);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var vendedor = await _vendedorRepository.GetByIdAsync(id);
        if (vendedor == null)
        {
            return NotFound();
        }
        return Ok(vendedor);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Vendedor vendedor)
    {
        if (vendedor.ID_Vendedor != null)
        {
            vendedor.ID_Vendedor = null; // Aseguramos que el ID sea nulo para que DynamoDB genere uno nuevo
        }
        await _vendedorRepository.AddAsync(vendedor);
        return CreatedAtAction(nameof(Get), new { id = vendedor.ID_Vendedor }, vendedor);
    }
    
    /*
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] Vendedor vendedor)
    {
        if (vendedor.ID_Vendedor != id)
        {
            return BadRequest("El ID del vendedor no coincide con el ID en la URL.");
        }
        
        await _vendedorRepository.UpdateAsync(id, vendedor);
        return NoContent();
    }
    */
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var vendedor = await _vendedorRepository.GetByIdAsync(id);
        if (vendedor == null)
        {
            return NotFound();
        }
        
        await _vendedorRepository.DeleteAsync(id);
        return NoContent();
    }
    
}