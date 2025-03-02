using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models;

public partial class TemasForo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? DateCreation { get; set; }

    public int UsuarioId { get; set; }

    public int CategoriaForoId { get; set; }

    public virtual CategoriasForo CategoriaForo { get; set; } = null!;

    public virtual ICollection<ComentariosForo> ComentariosForos { get; set; } = new List<ComentariosForo>();

    public virtual Usuario Usuario { get; set; } = null!;
}
