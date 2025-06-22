using Comision.API.Models;
using Comision.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comision.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReglaController: ControllerBase
{
    private readonly IRepository<Regla> _reglaRepository;
    
    public ReglaController(IRepository<Regla> reglaRepository)
    {
        _reglaRepository = reglaRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var reglas = await _reglaRepository.GetAllAsync();
        return Ok(reglas);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var regla = await _reglaRepository.GetByIdAsync(id);
        if (regla == null)
        {
            return NotFound();
        }
        return Ok(regla);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Regla regla)
    {
        if (regla.ID_Regla != null)
        {
            regla.ID_Regla = null; // Aseguramos que el ID sea nulo para que DynamoDB genere uno nuevo
        }
        await _reglaRepository.AddAsync(regla);
        return CreatedAtAction(nameof(Get), new { id = regla.ID_Regla }, regla);
    }
    
    /*
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] Regla regla)
    {
        if (regla.ID_Regla != id)
        {
            return BadRequest("El ID de la regla no coincide con el ID en la URL.");
        }
        
        await _reglaRepository.UpdateAsync(id, regla);
        return NoContent();
    }
    */
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _reglaRepository.DeleteAsync(id);
        return NoContent();
    }
}