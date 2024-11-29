using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? HorasSemanales { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
