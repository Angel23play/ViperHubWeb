using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Foro.Dto.Multimedium
{
    public class MultimediumResponse
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public string? Type { get; set; }
        public int UserId { get; set; }
        public DateTime? FechaSubida { get; set; }


    }
}
