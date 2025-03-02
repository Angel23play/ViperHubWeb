using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class ComentarioForoRepository : IComentariosForo
    {
        protected readonly ViperHubContext _db;
        public ComentarioForoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(ComentariosForo comentariosForo)
        {   
            _db.ComentariosForos.Add(comentariosForo);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<ComentariosForo> GetAll()
        {
            return _db.ComentariosForos.ToList();
        }

        public ComentariosForo GetById(int id)
        {
            return _db.ComentariosForos.Where(x=>x.Id==id).FirstOrDefault();
        }

        public ComentariosForo Update(ComentariosForo comentariosForo)
        {
            throw new NotImplementedException();
        }
    }
}
