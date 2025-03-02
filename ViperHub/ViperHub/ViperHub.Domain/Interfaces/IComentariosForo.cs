using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface IComentariosForo
    {
        public void Add(ComentariosForo ComentarioForo);
        public ComentariosForo GetById(int id);
        public ComentariosForo Update(ComentariosForo ComentarioForo);
        public void DeleteById(int id);
        public IEnumerable<ComentariosForo> GetAll();
    }
}
