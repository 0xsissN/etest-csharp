using Backend.Data;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly TestContext _testContext;

        public AuthController(IConfiguration config, TestContext testContext) 
        {
            _jwtService = new JwtService(config["Jwt:Key"]!);
            _testContext = testContext;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var user = await (from u in _testContext.Usuarios
                              where u.Username == usuario.Username && u.Password == _jwtService.EncriptarSHA256(usuario.Password)
                              select u).FirstOrDefaultAsync();

            if(user != null)
            {
                var token = _jwtService.GenerateToken(user.Username, user.Rol);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales incorrectas");
        }

        [HttpPost("Registrarse")]
        public async Task<IActionResult> Registrarse(string username, string password) 
        {
            var usuario = new Usuario()
            {
                Username = username,
                Password = _jwtService.EncriptarSHA256(password)
            };

            await _testContext.Usuarios.AddAsync(usuario);
            await _testContext.SaveChangesAsync();

            return Ok("Usuario registrado con exito");    
        }
    }
}
