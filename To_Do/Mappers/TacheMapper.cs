using To_Do.Models;
using To_Do.DTO;

namespace To_Do.Mappers;

public static class TacheMapper
{
  public static TacheReadAllDto ToReadDto(this Tache t)
  {
    return new TacheReadAllDto()
    {
      Id = t.Id,
      Titre = t.Titre,
      Description = t.Description,
      Statut = t.Statut
    };
  }

  public static Tache ToEntity(this TacheCreateDto dto)
  {
    return new Tache(
      dto.Titre,
      dto.Description ?? string.Empty
    );
  }
}