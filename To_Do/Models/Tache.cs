using System.Diagnostics.CodeAnalysis;
using To_Do.Enums;

namespace To_Do.Models;

public class Tache
{
  public int Id { get; private set; }

  public required string Titre { get; init; }
  public string? Description { get; private set; }

  public Taches_Statut Statut { get; private set; }
  public DateTime DateDeCreation { get; private init; }
  public DateTime UpdatedAt { get; private set; }

  public int ListeDeTachesId { get; private set; }
  public ListeDeTaches ListeDeTaches { get; private set; } = null!;

  [SetsRequiredMembers] // ici j'explique, fais-moi confiance, ce constructeur remplit tous les required. Merci Claude ^^...
  public Tache(string titre, string description)
  {
    if (string.IsNullOrWhiteSpace(titre))
      throw new ArgumentException(nameof(titre));

    Titre = titre.Trim();
    Description = description.Trim();
    Statut = Taches_Statut.EnCours;

    DateDeCreation = DateTime.Now;
    UpdatedAt = DateDeCreation;
  }

  protected Tache()
  {
  } // EF Core

  public void ModifierDescription(string nouvelleDescription)
  {
    if (nouvelleDescription != Description)
    {
      Description = nouvelleDescription;
      UpdatedAt = DateTime.Now;
    }
  }

  public void ModifierStatus(Taches_Statut nouveauStatut)
  {
    if (nouveauStatut != Statut)
    {
      Statut = nouveauStatut;
      UpdatedAt = DateTime.Now;
    }
  }
}