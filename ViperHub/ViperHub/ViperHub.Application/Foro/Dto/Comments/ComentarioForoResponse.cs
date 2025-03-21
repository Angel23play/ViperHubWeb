namespace ViperHub.Application.Foro.Dto.Comments
{
    public class ComentarioForoResponse
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? DateCreation { get; set; }
        public int UsuarioId { get; set; }
        public int TemaForoId { get; set; }
        public int? ComentarioPadreId { get; set; }


    }
}