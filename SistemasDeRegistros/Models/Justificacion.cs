using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Justificacion
{
    public int IdJustificacion { get; set; }

    public int? IdAsistencia { get; set; }

    public DateOnly FechaJustificacion { get; set; }

    public string MotivoJustificacion { get; set; } = null!;

    public string? DocumentoAdjunto { get; set; }

    public string? EstadoAprobacion { get; set; }

    public int? AprobadoPor { get; set; }

    public string? Observaciones { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Usuario? AprobadoPorNavigation { get; set; }

    public virtual Asistencium? IdAsistenciaNavigation { get; set; }
}
