using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Apoderado
{
    public int IdApoderado { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Parentesco { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Ocupacion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<AlumnoApoderado> AlumnoApoderados { get; set; } = new List<AlumnoApoderado>();
}
