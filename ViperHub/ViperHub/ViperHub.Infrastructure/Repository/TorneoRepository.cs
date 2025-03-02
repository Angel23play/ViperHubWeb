using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class TorneoRepository : ITorneos
    {
        protected readonly ViperHubContext _db;
        public TorneoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(Torneo torneo)
        {
            _db.Torneos.Add(torneo);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<Torneo> GetAll()
        {
            return _db.Torneos.ToList();
        }

        public Torneo GetById(int id)
        {
            return _db.Torneos.Where(x=>x.Id==id).FirstOrDefault();
        }

        public Torneo Update(Torneo torneo)
        {
            throw new NotImplementedException();
        }
    }
}
