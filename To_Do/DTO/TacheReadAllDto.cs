using To_Do.Models;
using To_Do.Enums;

namespace To_Do.DTO;

public class TacheReadAllDto
{
  public int Id { get; set; }
  public required string Titre { get; set; }
  public string? Description { get; set; }
  public Taches_Statut Statut { get; set; }
}