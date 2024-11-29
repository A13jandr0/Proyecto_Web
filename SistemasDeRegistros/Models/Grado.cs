using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Grado
{
    public int IdGrado { get; set; }

    public int? IdNivelEducativo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual NivelEducativo? IdNivelEducativoNavigation { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
