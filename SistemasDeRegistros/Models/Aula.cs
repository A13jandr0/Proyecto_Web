using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Capacidad { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
