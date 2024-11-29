using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class ConfiguracionSistema
{
    public int IdConfiguracion { get; set; }

    public string Clave { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
