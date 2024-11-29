using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    public int? IdUsuario { get; set; }

    public string Codigo { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
