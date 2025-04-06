using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models
{


public partial class Clane
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? ImagenUrl { get; set; }
        
    public int LiderId { get; set; }

    public virtual ICollection<EquiposTorneo> EquiposTorneos { get; set; } = new List<EquiposTorneo>();

    public virtual Usuario Lider { get; set; } = null!;
    
    public virtual ICollection<UsuarioClane> UsuarioClanes { get; set; } = new List<UsuarioClane>();
}

}