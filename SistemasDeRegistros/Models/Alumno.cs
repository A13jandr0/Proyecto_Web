using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public int? IdUsuario { get; set; }

    public string Codigo { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public string? EstadoAcademico { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<AlumnoApoderado> AlumnoApoderados { get; set; } = new List<AlumnoApoderado>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
