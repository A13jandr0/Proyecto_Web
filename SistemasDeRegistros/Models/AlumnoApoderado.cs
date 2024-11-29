using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class AlumnoApoderado
{
    public int IdAlumnoApoderado { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdApoderado { get; set; }

    public bool? EsPrincipal { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Apoderado? IdApoderadoNavigation { get; set; }
}
