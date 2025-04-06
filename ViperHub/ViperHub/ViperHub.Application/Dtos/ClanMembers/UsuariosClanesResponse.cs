using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Dto.ClanMembers
{
    public class UsuariosClanesResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClanId { get; set; }
        public int Rol { get; set; }


    }
}
