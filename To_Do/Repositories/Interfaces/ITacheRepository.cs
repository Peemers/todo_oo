using To_Do.Models;
using To_Do.Enums;


namespace To_Do.Repositories.Interfaces;

internal interface ITacheRepository : IRepository<Tache>
{
  // Méthodes spécifiques aux tâches uniquement
  Task<IEnumerable<Tache>> GetByStatutAsync(Taches_Statut statut);
  Task<IEnumerable<Tache>> GetByListeAsync(int listeDeTachesId);
}