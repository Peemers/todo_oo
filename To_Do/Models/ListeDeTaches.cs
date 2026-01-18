using To_Do.Enums;

namespace To_Do.Models;

public class ListeDeTaches
{
  public int Id { get; private set; }

  public ICollection<Tache> Taches { get; private set; } = new List<Tache>();

  public ListeDeTaches()
  {
  }

  public void AjouterTache(string titre, string description)
  {
    var tache = new Tache(titre, description);
    Taches.Add(tache);
  }

  public void ModifierStatus(int tacheId, Taches_Statut nouveauStatus)
  {
    var tache = Taches.FirstOrDefault(t => t.Id == tacheId)
                ?? throw new ArgumentException(nameof(tacheId));

    tache.ModifierStatus(nouveauStatus);
  }

  public void SupprimerTache(int tacheId)
  {
    var tache = Taches.FirstOrDefault(t => t.Id == tacheId)
                ?? throw new ArgumentException(nameof(tacheId));

    Taches.Remove(tache);
  }

  public IReadOnlyList<Tache> Lister()
    => Taches.ToList();

  public (int EnCours, int EnAttente, int Terminees) Statistiques()
  {
    return (
      Taches.Count(t => t.Statut == Taches_Statut.EnCours),
      Taches.Count(t => t.Statut == Taches_Statut.EnAttente),
      Taches.Count(t => t.Statut == Taches_Statut.Terminee)
    );
  }
}