using Backend.Data;
using Backend.Models;
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
        [HttpGet]
        public async Task<IActionResult> GetEstudiante()
        {
            var estudiantes = await (from est in _testContext.Estudiantes
                                     select est).ToListAsync();

            return Ok(estudiantes);
        }

        [HttpPost]
        public async Task<IActionResult> PostEstudiante(string ci, string nombre, string apellido_paterno, string apellido_materno, DateOnly fecha_nacimiento)
        {
            var comprobando_ci = await (from est in _testContext.Estudiantes
                                        where est.Ci == ci
                                        select est).FirstOrDefaultAsync();

            if (comprobando_ci != null)
            {
                return BadRequest("Ci del estudiante ya creado");
            }

            var nuevo_estudiante = new Estudiante()
            {
                Ci = ci,
                Nombre = nombre,
                Apellido_Paterno = apellido_paterno,
                Apellido_Materno = apellido_materno,
                Fecha_Nacimiento = fecha_nacimiento
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
                return BadRequest("Ci del estudiante no registrado");
            }

            existencia_estudiante.Estado = false;

            await _testContext.SaveChangesAsync();

            return Ok("Estudiante eliminado con exito");
        }

        [HttpPut]
        public async Task<IActionResult> PutEstudiante(string ci, string nombre, string apellido_paterno, string apellido_materno, DateOnly fecha_nacimiento, bool estado)
        {
            var existencia_estudiante = await (from est in _testContext.Estudiantes
                                               where est.Ci == ci
                                               select est).FirstOrDefaultAsync();

            if (existencia_estudiante == null)
            {
                return BadRequest("Ci del estudiante no registrado");
            }

            existencia_estudiante.Nombre = nombre;
            existencia_estudiante.Apellido_Paterno = apellido_paterno;
            existencia_estudiante.Apellido_Materno = apellido_materno;
            existencia_estudiante.Fecha_Nacimiento = fecha_nacimiento;
            existencia_estudiante.Estado = estado;

            await _testContext.SaveChangesAsync();

            return Ok("Estudiane actualizado con exito");
        }
    }
}
