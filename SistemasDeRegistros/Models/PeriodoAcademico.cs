using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class PeriodoAcademico
{
    public int IdPeriodoAcademico { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string? Estado { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
