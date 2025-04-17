using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Dto.ClanMembers
{
    public class UsuariosClanesDto
    {

        public int UsuarioId { get; set; }
        public int ClanId { get; set; }
        public int Rol { get; set; } // si el valor es 1 mostrar Lider, si el valor es 2 mostrar Miembro



    }
}
