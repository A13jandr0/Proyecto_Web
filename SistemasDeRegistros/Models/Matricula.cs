using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Matricula
{
    public int IdMatricula { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdPeriodoAcademico { get; set; }

    public int? IdGrado { get; set; }

    public int? IdSeccion { get; set; }

    public DateOnly FechaMatricula { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Grado? IdGradoNavigation { get; set; }

    public virtual PeriodoAcademico? IdPeriodoAcademicoNavigation { get; set; }

    public virtual Seccion? IdSeccionNavigation { get; set; }
}
