using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface IMultimedium
    {
        public void Add(Multimedium Multimedia);
        public Multimedium GetById(int id);
        public Multimedium Update(Multimedium Multimedia);
        public void DeleteById(int id);
        public IEnumerable<Multimedium> GetAll();
    }
}
