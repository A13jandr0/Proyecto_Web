using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class NivelEducativo
{
    public int IdNivelEducativo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? EdadMinima { get; set; }

    public int? EdadMaxima { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Grado> Grados { get; set; } = new List<Grado>();
}
