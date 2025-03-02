using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface IClanes
    {
        public void Add(Clane Clan);
        public Clane GetById(int id);
        public Clane Update(Clane Clan);
        public void DeleteById(int id);
        public IEnumerable<Clane> GetAll();
    }
}