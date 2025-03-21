﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViperHub.Domain.Models;

public partial class CategoriasForo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;


    public virtual ICollection<TemasForo> TemasForos { get; set; } = new List<TemasForo>();
}
