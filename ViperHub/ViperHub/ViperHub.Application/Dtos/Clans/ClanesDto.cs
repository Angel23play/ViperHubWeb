using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Dto.Clans
{


        public class ClanesDto
        {

            public string Name { get; set; } = null!;
            public string? Descripcion { get; set; }
            public string? ImagenUrl { get; set; }
            public int LiderId { get; set; }

           /*
            public UsuarioDto Lider { get; set; } = null!;
            public List<UsuariosClanesDto> UsuarioClanes { get; set; } = new List<UsuariosClanesDto>();
            public List<EquiposTorneoDto> EquiposTorneos { get; set; } = new List<EquiposTorneoDto>();
            */
        }

    
}
