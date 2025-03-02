using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class ClaneRepository : IClanes
    {
        protected readonly ViperHubContext _db;
        public ClaneRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(Clane Clan)
        {
  
            _db.Clanes.Add(Clan);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<Clane> GetAll()
        {
            return _db.Clanes.ToList();
        }

        public Clane GetById(int id)
        {
            return _db.Clanes.Where(x=>x.Id==id).FirstOrDefault();
        }

        public Clane Update(Clane Clan)
        {
            throw new NotImplementedException();
        }

    }
}
