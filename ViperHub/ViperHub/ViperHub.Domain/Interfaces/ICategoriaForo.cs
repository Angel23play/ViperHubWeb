using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface ICategoriaForo
    {
        public void Add(CategoriasForo categorias);
        public CategoriasForo GetById(int id);
        public CategoriasForo Update(CategoriasForo categorias);
        public void DeleteById(int id);
        public IEnumerable<CategoriasForo> GetAll();

    }
}
