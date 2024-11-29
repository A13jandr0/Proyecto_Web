using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasDeRegistros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemasDeRegistros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DbControlAsistenciaEscolarContext _context;

        public AuthController(DbControlAsistenciaEscolarContext context)
        {
            _context = context;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == loginRequest.Username);

            // Verifica si el usuario existe y si la contraseña es correcta
            if (user == null || !VerifyPassword(loginRequest.Password, user.Contrasena))
            {
                return Unauthorized("Nombre de usuario o contraseña incorrectos");
            }

            // Verifica si la cuenta está bloqueada
            if (user.CuentaBloqueada == true)
            {
                return Unauthorized("Cuenta bloqueada. Contacte al administrador.");
            }

            // Genera un token simple (no seguro para producción)
            var token = GenerateSimpleToken(user.NombreUsuario);
            return Ok(new { token });
        }

        // Genera un token simple basado en el nombre de usuario y una marca de tiempo
        private string GenerateSimpleToken(string username)
        {
            var tokenData = $"{username}:{DateTime.UtcNow}";
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(tokenData));
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Verificación básica de la contraseña (sin encriptación)
        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // Para propósitos de prueba se hace una comparación directa.
            return inputPassword == storedPassword;
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
