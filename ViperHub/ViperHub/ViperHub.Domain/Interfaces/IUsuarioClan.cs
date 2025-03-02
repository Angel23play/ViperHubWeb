using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface IUsuariosClan
    {
        public void Add(UsuarioClane UsuarioClan);
        public UsuarioClane GetById(int id);
        public UsuarioClane Update(UsuarioClane UsuarioClan);
        public void DeleteById(int id);
        public IEnumerable<UsuarioClane> GetAll();
    }
}
