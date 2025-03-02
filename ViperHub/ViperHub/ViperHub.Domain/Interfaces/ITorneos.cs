using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface ITorneos
    {
        public void Add(Torneo Torneo);
        public Torneo GetById(int id);
        public Torneo Update(Torneo Torneo);
        public void DeleteById(int id);
        public IEnumerable<Torneo> GetAll();
    }
}
