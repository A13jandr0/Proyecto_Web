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
    public class UsuarioController : ControllerBase
    {
        private readonly DbControlAsistenciaEscolarContext _context;

        public UsuarioController(DbControlAsistenciaEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> GetUsuarios([FromQuery] List<int>? roleIds = null)
        {
            IQueryable<Usuario> query = _context.Usuarios.Include(u => u.IdRolNavigation);

            if (roleIds != null && roleIds.Any())
            {
                // Filtrar usuarios por los IdRol especificados
                query = query.Where(u => roleIds.Contains(u.IdRol ?? 0));
            }

            // Proyección para mostrar solo los campos necesarios
            var usuarios = await query.Select(u => new
            {
                u.IdUsuario,
                u.Nombres,
                u.Apellidos,
                u.Email,
                u.NombreUsuario,
                u.UltimoAcceso,
                u.IntentosAccesoFallidos,
                u.CuentaBloqueada,
                u.Activo,
                Rol = u.IdRolNavigation != null ? u.IdRolNavigation.Nombre : "Sin rol asignado"
            }).ToListAsync();

            return Ok(usuarios);
        }
    }
}
