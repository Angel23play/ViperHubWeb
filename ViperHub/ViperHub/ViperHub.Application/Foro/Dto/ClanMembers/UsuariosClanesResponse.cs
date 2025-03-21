using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Foro.Dto.ClanMembers
{
    public class UsuariosClanesResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClanId { get; set; }
        public string? Rol { get; set; }


    }
}
