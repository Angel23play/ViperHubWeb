using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Foro.Dto.Themes
{
    public class TemasForoDto 
    {
      
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int UsuarioId { get; set; } 
        public int CategoriaForoId { get; set; } 
        public DateTime? DateCreation { get; set; }

       
    }
}
