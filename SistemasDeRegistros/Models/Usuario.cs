using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime? UltimoAcceso { get; set; }

    public int? IntentosAccesoFallidos { get; set; }

    public bool? CuentaBloqueada { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Justificacion> Justificacions { get; set; } = new List<Justificacion>();
}
