using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int? IdPeriodoAcademico { get; set; }

    public int? IdGrado { get; set; }

    public int? IdSeccion { get; set; }

    public int? IdCurso { get; set; }

    public int? IdDocente { get; set; }

    public int? IdAula { get; set; }

    public string DiaSemana { get; set; } = null!;

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();

    public virtual Aula? IdAulaNavigation { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Docente? IdDocenteNavigation { get; set; }

    public virtual Grado? IdGradoNavigation { get; set; }

    public virtual PeriodoAcademico? IdPeriodoAcademicoNavigation { get; set; }

    public virtual Seccion? IdSeccionNavigation { get; set; }
}
