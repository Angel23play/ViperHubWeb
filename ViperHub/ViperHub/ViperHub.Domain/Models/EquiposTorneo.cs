using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models;

public partial class EquiposTorneo
{
    public int Id { get; set; }

    public int ClanId { get; set; }

    public int TorneoId { get; set; }

    public int? Points { get; set; }

    public virtual Clane Clan { get; set; } = null!;

    public virtual Torneo Torneo { get; set; } = null!;
}
