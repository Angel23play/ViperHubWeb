using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class MultimediumRepository : IMultimedium
    {
        protected readonly ViperHubContext _db;
        public MultimediumRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(Multimedium multimedium)
        {
            _db.Multimedia.Add(multimedium);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<Multimedium> GetAll()
        {
            return _db.Multimedia.ToList();
        }

        public Multimedium GetById(int id)
        {
            return _db.Multimedia.Where(x=>x.Id==id).FirstOrDefault();
        }

        public Multimedium Update(Multimedium multimedium)
        {
            throw new NotImplementedException();
        }
    }
}
