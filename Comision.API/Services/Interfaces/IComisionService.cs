using Comision.API.Services.DTOs;

namespace Comision.API.Services.Interfaces;

public interface IComisionService
{
    Task<IEnumerable<ComisionResultadoDto>> CalcularComisionesAsync(DateTime fechaInicio, DateTime fechaFin);
}