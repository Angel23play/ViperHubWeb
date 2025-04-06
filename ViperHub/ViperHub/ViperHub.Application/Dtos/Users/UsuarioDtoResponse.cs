using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;


namespace ViperHub.Application.Dto.Users
{
    public class UsuarioResponse
    {


        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;


    }
}