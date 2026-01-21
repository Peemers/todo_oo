using Microsoft.AspNetCore.Mvc;
using To_Do.Repositories.Interfaces;
using To_Do.DTO;
using To_Do.Mappers;
using System.Linq;

namespace To_Do.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TachesController : ControllerBase
{
  private readonly ITacheRepository _tacheRepository;

  public TachesController(ITacheRepository tacheRepository)
  {
    _tacheRepository = tacheRepository;
  }

  
  [HttpGet]
  public async Task<ActionResult<IEnumerable<TacheReadAllDto>>> GetAll()
  {
    var taches = await _tacheRepository.GetAllAsync();
    var result = taches.Select(t => t.ToReadDto());

    return Ok(result);
  }

  
  [HttpGet("{id}")]
  public async Task<ActionResult<TacheReadAllDto>> GetById(int id)
  {
    var tache = await _tacheRepository.GetByIdAsync(id);

    if (tache == null)
      return NotFound();

    return Ok(tache.ToReadDto());
  }

  
  [HttpPost]
  public async Task<ActionResult<TacheReadAllDto>> Create(TacheCreateDto dto)
  {
    var tache = dto.ToEntity();

    await _tacheRepository.AddAsync(tache);

    return CreatedAtAction(
      nameof(GetById),
      new { id = tache.Id },
      tache.ToReadDto()
    );
  }

  
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _tacheRepository.DeleteAsyncById(id);
    return NoContent();
  }
}