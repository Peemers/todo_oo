using To_Do.Models;
using Microsoft.AspNetCore.Mvc;

namespace To_Do.DTO;

public class TacheCreateDto
{
  public string Titre { get; set; } = null!;
  public string? Description { get; set; }
}