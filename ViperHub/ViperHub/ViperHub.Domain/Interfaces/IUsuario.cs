using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface IUsuario
    {   
        public void Add(Usuario Usuario);
        public Usuario GetById(int id);
        public Usuario Update(Usuario Usuario);
        public void DeleteById(int id);
        public IEnumerable<Usuario> GetAll();
    }
}
