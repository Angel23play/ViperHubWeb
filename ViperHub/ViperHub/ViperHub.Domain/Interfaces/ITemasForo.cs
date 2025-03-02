using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface ITemasForo
    {
        public void Add(TemasForo TemaForo);
        public TemasForo GetById(int id);
        public TemasForo Update(TemasForo TemaForo);
        public void DeleteById(int id);
        public IEnumerable<TemasForo> GetAll();
    }
}
