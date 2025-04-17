using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models
{


public partial class Torneo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<EquiposTorneo> EquiposTorneos { get; set; } = new List<EquiposTorneo>();

    public virtual Usuario User { get; set; } = null!;
}

}