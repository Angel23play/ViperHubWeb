using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Dto.Teams
{
    public class EquiposTorneoResponse
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public int TorneoId { get; set; }
        public int? Points { get; set; }

    }
}
