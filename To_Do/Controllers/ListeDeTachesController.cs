using Microsoft.AspNetCore.Mvc;
using To_Do.Repositories.Interfaces;
using To_Do.DTO;
using To_Do.Mappers;
using System.Linq;
using Microsoft.VisualBasic;
using To_Do.Models;

[ApiController]
[Route("api/[controller]")]

public class ListeDeTachesController : ControllerBase
{
  private readonly IListeDeTachesRepository _listeDeTachesRepository;

  public ListeDeTachesController(IListeDeTachesRepository listeDeTachesRepository)
  {
    _listeDeTachesRepository = listeDeTachesRepository;
  }

  [HttpGet]

  public async Task<ActionResult<IEnumerable<ReadListeDeTachesDto>>> GetAll()
  {
    var listesDeTaches = await _listeDeTachesRepository.GetAllAsync();
    var result = listesDeTaches.Select(t => t.ToReadDto());
    
    return Ok(result);
  }

  [HttpGet("{id}")]

  public async Task<ActionResult<ReadListeDeTachesDto>> GetById(int id)
  {
    var liste = await _listeDeTachesRepository.GetByIdAsync(id);
    if (liste == null)
    {
      return NotFound();
    }
    return Ok(liste.ToReadDto());
  }
  
  [HttpPost]
  public async Task<ActionResult<ReadListeDeTachesDto>> Create()
  {
    var liste = new ListeDeTaches();

    await _listeDeTachesRepository.AddAsync(liste);

    return CreatedAtAction(
      nameof(GetById),
      new { id = liste.Id },
      liste.ToReadDto()
    );
  }

}