using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;


namespace ViperHub.Application.Foro.Dto.Users
{
    public class UsuarioDto
    {
        
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? RegisterDate { get; set; }

     
    }
}