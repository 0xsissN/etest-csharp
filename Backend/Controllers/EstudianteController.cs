using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : Controller
    {
        private readonly TestContext _testContext;

        public EstudianteController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEstudiante()
        {
            var estudiantes = await (from est in _testContext.Estudiantes
                                     select est).ToListAsync();

            return Ok(estudiantes);
        }

        [HttpPost]
        public async Task<IActionResult> PostEstudiante(Estudiante estudiante)
        {
            var comprobando_ci = await (from est in _testContext.Estudiantes
                                        where est.Ci == estudiante.Ci
                                        select est).FirstOrDefaultAsync();

            if (comprobando_ci != null)
            {
                return BadRequest("Ci del estudiante ya creado");
            }

            var nuevo_estudiante = new Estudiante()
            {
                Ci = estudiante.Ci,
                Nombre = estudiante.Nombre,
                ApellidoPaterno = estudiante.ApellidoPaterno,
                ApellidoMaterno = estudiante.ApellidoMaterno,
                FechaNacimiento = estudiante.FechaNacimiento
            };

            await _testContext.Estudiantes.AddAsync(nuevo_estudiante);
            await _testContext.SaveChangesAsync();

            return Ok("Estudiante creado con exito");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEstudiante(string ci)
        {
            var existencia_estudiante = await (from est in _testContext.Estudiantes
                                               where est.Ci == ci
                                               select est).FirstOrDefaultAsync();

            if (existencia_estudiante == null)
            {
                return NotFound("Ci del estudiante no registrado");
            }

            existencia_estudiante.Estado = false;

            await _testContext.SaveChangesAsync();

            return Ok("Estudiante eliminado con exito");
        }

        [HttpPut]
        public async Task<IActionResult> PutEstudiante(Estudiante estudiante)
        {
            var existencia_estudiante = await (from est in _testContext.Estudiantes
                                               where est.Ci == estudiante.Ci
                                               select est).FirstOrDefaultAsync();

            if (existencia_estudiante == null)
            {
                return NotFound("Ci del estudiante no registrado");
            }

            existencia_estudiante.Nombre = estudiante.Nombre;
            existencia_estudiante.ApellidoPaterno = estudiante.ApellidoPaterno;
            existencia_estudiante.ApellidoMaterno = estudiante.ApellidoMaterno;
            existencia_estudiante.FechaNacimiento = estudiante.FechaNacimiento;
            existencia_estudiante.Estado = estudiante.Estado;

            await _testContext.SaveChangesAsync();

            return Ok("Estudiane actualizado con exito");
        }
    }
}
