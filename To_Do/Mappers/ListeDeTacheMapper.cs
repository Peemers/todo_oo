using To_Do.DTO;
using To_Do.Models;

namespace To_Do.Mappers;

public static class ListeDeTachesMapper
{
  public static ReadListeDeTachesDto ToReadDto(this ListeDeTaches liste)
  {
    return new ReadListeDeTachesDto
    {
      Id = liste.Id
    };
  }
}