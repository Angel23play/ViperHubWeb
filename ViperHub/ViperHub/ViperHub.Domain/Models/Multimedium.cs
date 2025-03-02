using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models;

public partial class Multimedium
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public string? Type { get; set; }

    public int UserId { get; set; }

    public DateTime? FechaSubida { get; set; }

    public virtual Usuario User { get; set; } = null!;
}
