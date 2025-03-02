using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class UsuarioClaneRepository : IUsuariosClan
    {
        protected readonly ViperHubContext _db;
        public UsuarioClaneRepository(ViperHubContext viperHubContext)
        {
            _db = viperHubContext;
        }
        public void Add(UsuarioClane usuarioClane)
        {
            _db.UsuarioClanes.Add(usuarioClane);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {

        }

        public IEnumerable<UsuarioClane> GetAll()
        {
            return _db.UsuarioClanes.ToList();
        }

        public UsuarioClane GetById(int id)
        {
            return _db.UsuarioClanes.Where(x => x.Id == id).FirstOrDefault();
        }

        public UsuarioClane Update(UsuarioClane usuarioClane)
        {
            throw new NotImplementedException();
        }
    }
}
