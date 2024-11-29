using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Seccion
{
    public int IdSeccion { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Capacidad { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
