using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Dto.Clans
{


    public class ClanesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? ImagenUrl { get; set; }
        public int LiderId { get; set; }

      
    }


}
