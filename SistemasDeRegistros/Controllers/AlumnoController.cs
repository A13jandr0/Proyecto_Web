using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasDeRegistros.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasDeRegistros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly DbControlAsistenciaEscolarContext _context;

        public AlumnoController(DbControlAsistenciaEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Alumno/asistencia
        [HttpGet("asistencia")]
        public async Task<IActionResult> GetAlumnosConAsistencia()
        {
            var alumnosConAsistencia = await _context.Alumnos
                .Include(a => a.IdUsuarioNavigation)
                .Include(a => a.Matriculas)
                    .ThenInclude(m => m.Asistencia)  // Incluye la asistencia de cada matrícula
                .Select(a => new
                {
                    a.IdAlumno,
                    a.Codigo,
                    NombreCompleto = a.IdUsuarioNavigation != null
                        ? $"{a.IdUsuarioNavigation.Nombres} {a.IdUsuarioNavigation.Apellidos}"
                        : "Sin nombre asignado",
                    a.Dni,
                    a.FechaNacimiento,
                    a.Telefono,
                    AsistenciaStatus = a.Matriculas.Any(m => m.Asistencia.Any()) ? "✔" : "✘",
                    Asistencias = a.Matriculas.SelectMany(m => m.Asistencia).Select(asistencia => new
                    {
                        asistencia.IdAsistencia,
                        asistencia.Fecha,
                        asistencia.EstadoAsistencia,
                        asistencia.HoraRegistro,
                        asistencia.Observaciones,
                        RegistradoPor = asistencia.RegistradoPorNavigation != null
                            ? $"{asistencia.RegistradoPorNavigation.Nombres} {asistencia.RegistradoPorNavigation.Apellidos}"
                            : "No especificado"
                    }).ToList()
                }).ToListAsync();

            return Ok(alumnosConAsistencia);
        }
    }
}
