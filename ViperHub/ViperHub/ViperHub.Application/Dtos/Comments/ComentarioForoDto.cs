namespace ViperHub.Application.Dto.Comments
{
    public class ComentarioForoDto
    {

        public string Content { get; set; } = null!;
        public DateTime? DateCreation { get; set; }
        public int UsuarioId { get; set; }
        public int TemaForoId { get; set; }
        public int? ComentarioPadreId { get; set; }


    }
}