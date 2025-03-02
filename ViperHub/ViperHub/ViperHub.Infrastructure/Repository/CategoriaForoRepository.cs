using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class CategoriaForoRepository : ICategoriaForo
    {
        protected readonly ViperHubContext _db;
        public CategoriaForoRepository(ViperHubContext viperHubContext)
        {
            _db = viperHubContext;
        }
        public void Add(CategoriasForo categorias)
        {
            _db.CategoriasForos.Add(categorias);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<CategoriasForo> GetAll()
        {
            return _db.CategoriasForos.ToList();
        }

        public CategoriasForo GetById(int id)
        {
            return _db.CategoriasForos.Where(x=>x.Id==id).FirstOrDefault();
        }

        public CategoriasForo Update(CategoriasForo categorias)
        {
            throw new NotImplementedException();
        }
    }
}
