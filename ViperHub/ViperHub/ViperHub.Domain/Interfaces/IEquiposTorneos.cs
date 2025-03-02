using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Domain.Interfaces
{
    public interface IEquiposTorneos
    {
        public void Add(EquiposTorneo EquipoTorneo);
        public EquiposTorneo GetById(int id);
        public EquiposTorneo Update(EquiposTorneo EquipoTorneo);
        public void DeleteById(int id);
        public IEnumerable<EquiposTorneo> GetAll();
    }
}
