using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class TemasForoRepository : ITemasForo
    {
        protected readonly ViperHubContext _db;
        public TemasForoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(TemasForo temasForo)
        {
            _db.TemasForos.Add(temasForo);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<TemasForo> GetAll()
        {
            return _db.TemasForos.ToList();
        }

        public TemasForo GetById(int id)
        {
            return _db.TemasForos.Where(x=>x.Id==id).FirstOrDefault();
        }

        public TemasForo Update(TemasForo categorias)
        {
            throw new NotImplementedException();
        }
    }
}
