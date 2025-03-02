using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models;

public partial class ComentariosForo
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? DateCreation { get; set; }

    public int UsuarioId { get; set; }

    public int TemaForoId { get; set; }

    public int? ComentarioPadreId { get; set; }

    public virtual ComentariosForo? ComentarioPadre { get; set; }

    public virtual ICollection<ComentariosForo> InverseComentarioPadre { get; set; } = new List<ComentariosForo>();

    public virtual TemasForo TemaForo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
