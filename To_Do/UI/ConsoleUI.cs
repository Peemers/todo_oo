namespace To_Do.UI;

using To_Do.Models;
using To_Do.Enums;

public class ConsoleUI
{
  private readonly ListeDeTaches _liste;

  #region Constructeur

  public ConsoleUI(ListeDeTaches liste)
  {
    _liste = liste;
  }

  #endregion

  #region Run

  public void Run()
  {
    while (true)
    {
      AfficherMenu();

      var choix = Console.ReadLine();

      if (choix?.ToLower() == "q")
        break;

      try
      {
        GererChoix(choix);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erreur : {ex.Message}");
        Console.ReadLine();
      }
    }
  }

  #endregion

  #region Menu

  private void AfficherMenu()
  {
    Console.Clear();
    Console.WriteLine("=== TODO LIST ===");
    Console.WriteLine("1 - Ajouter une tâche");
    Console.WriteLine("2 - Modifier le statut");
    Console.WriteLine("3 - Statistiques");
    Console.WriteLine("4 - Afficher les tâches");
    Console.WriteLine("5 - Supprimer une tâche");
    Console.WriteLine("Q - Quitter");
  }

  private void GererChoix(string choix)
  {
    switch (choix)
    {
      case "1":
        AjouterTacheUI();
        break;

      case "2":
        ModifierStatutUI();
        break;

      case "3":
        AfficherStatistiquesUI();
        break;

      case "4":
        AfficherTachesUI();
        break;

      case "5":
        SupprimerTacheUI();
        break;
    }
  }

  #endregion

  #region AjouterTache

  private void AjouterTacheUI()
  {
    Console.Clear();
    Console.Write("Titre : ");
    var titre = Console.ReadLine();

    Console.Write("Description : ");
    var description = Console.ReadLine();

    _liste.AjouterTache(titre!, description!);

    Console.WriteLine("Tâche ajoutée.");
    Console.ReadLine();
  }

  #endregion

  #region ModifierStatut

  private void ModifierStatutUI()
  {
    Console.Clear();

    var taches = _liste.Lister();

    if (taches.Count == 0)
    {
      Console.WriteLine("Aucune tâche.");
      Console.ReadLine();
      return;
    }

    foreach (var t in taches)
    {
      Console.WriteLine($"{t.Id}. {t.Titre} ({t.Statut})");
    }

    Console.Write("Id de la tâche : ");
    var inputId = Console.ReadLine();

    if (!int.TryParse(inputId, out int tacheId))
    {
      Console.WriteLine("Id invalide.");
      Console.ReadLine();
      return;
    }

    Console.WriteLine("1-EnAttente  2-EnCours  3-Terminée");
    var choix = Console.ReadLine();

    var statut = choix switch
    {
      "1" => Taches_Statut.EnAttente,
      "2" => Taches_Statut.EnCours,
      "3" => Taches_Statut.Terminee,
      _ => throw new ArgumentException("Statut invalide")
    };

    _liste.ModifierStatus(tacheId, statut);

    Console.WriteLine("Statut mis à jour.");
    Console.ReadLine();
  }

  #endregion

  #region SupprimerTache

  private void SupprimerTacheUI()
  {
    Console.Clear();

    var taches = _liste.Lister();

    if (taches.Count == 0)
    {
      Console.WriteLine("Aucune tâche à supprimer.");
      Console.ReadLine();
      return;
    }

    foreach (var t in taches)
    {
      Console.WriteLine($"{t.Id}. {t.Titre}");
    }

    Console.Write("Id de la tâche à supprimer : ");
    var input = Console.ReadLine();

    if (!int.TryParse(input, out int tacheId))
    {
      Console.WriteLine("Id invalide.");
      Console.ReadLine();
      return;
    }

    _liste.SupprimerTache(tacheId);

    Console.WriteLine("Tâche supprimée");
    Console.ReadLine();
  }

  #endregion

  #region Statistiques

  private void AfficherStatistiquesUI()
  {
    Console.Clear();

    var stats = _liste.Statistiques();

    Console.WriteLine($"{stats.EnCours} tâches en cours");
    Console.WriteLine($"{stats.EnAttente} tâches en attente");
    Console.WriteLine($"{stats.Terminees} tâches terminées");

    Console.ReadLine();
  }

  #endregion

  #region AfficherTaches

  private void AfficherTachesUI()
  {
    Console.Clear();

    var taches = _liste.Lister();

    if (taches.Count == 0)
    {
      Console.WriteLine("Aucune tâche.");
      Console.ReadLine();
      return;
    }

    foreach (var t in taches)
    {
      Console.WriteLine($"{t.Id}. {t.Titre}");
      Console.WriteLine($"   Description : {t.Description}");
      Console.WriteLine($"   Statut      : {t.Statut}");
      Console.WriteLine($"   Créée le    : {t.DateDeCreation}");
      Console.WriteLine();
    }

    Console.WriteLine("Appuyez sur Entrée pour revenir au menu");
    Console.ReadLine();
  }

  #endregion
}
