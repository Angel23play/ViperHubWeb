using System;
using System.Collections.Generic;

namespace ViperHub.Domain.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? RegisterDate { get; set; }

    public virtual ICollection<Clane> Clanes { get; set; } = new List<Clane>();

    public virtual ICollection<ComentariosForo> ComentariosForos { get; set; } = new List<ComentariosForo>();

    public virtual ICollection<Multimedium> Multimedia { get; set; } = new List<Multimedium>();

    public virtual ICollection<TemasForo> TemasForos { get; set; } = new List<TemasForo>();

    public virtual ICollection<Torneo> Torneos { get; set; } = new List<Torneo>();

    public virtual ICollection<UsuarioClane> UsuarioClanes { get; set; } = new List<UsuarioClane>();
}
