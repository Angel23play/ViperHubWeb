using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuario
    {
        protected readonly ViperHubContext _db;
        public UsuarioRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _db.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _db.Usuarios.Where(x=>x.Id==id).FirstOrDefault();
        }

        public Usuario Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
