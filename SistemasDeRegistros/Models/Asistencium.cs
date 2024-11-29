using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Asistencium
{
    public int IdAsistencia { get; set; }

    public int? IdMatricula { get; set; }

    public int? IdHorario { get; set; }

    public DateOnly Fecha { get; set; }

    public string EstadoAsistencia { get; set; } = null!;

    public TimeOnly? HoraRegistro { get; set; }

    public string? Observaciones { get; set; }

    public int? RegistradoPor { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Horario? IdHorarioNavigation { get; set; }

    public virtual Matricula? IdMatriculaNavigation { get; set; }

    public virtual ICollection<Justificacion> Justificacions { get; set; } = new List<Justificacion>();

    public virtual Usuario? RegistradoPorNavigation { get; set; }
}
