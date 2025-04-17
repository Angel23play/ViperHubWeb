using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models
{


public partial class UsuarioClane
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ClanId { get; set; }

    public int? Rol { get; set; }

    public virtual Clane Clan { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

}