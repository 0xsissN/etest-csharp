using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly TestContext _testContext;
        public TestController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            var tests = await (from t in _testContext.Tests
                               join e in _testContext.Estudiantes on t.Estudiante_ci equals e.Id
                               join co in _testContext.Colegios on t.Colegio_id equals co.Id
                               join cu in _testContext.Cursos on t.Curso_id equals cu.Id
                               join u in _testContext.Usuarios on t.Usuario_id equals u.Id
                               select new
                               {
                                   t.Id,
                                   t.Codigo,
                                   Ci = e.Ci,
                                   CodigoColegio = co.Codigo,
                                   CursoId = cu.Id,
                                   Nombre_Estudiante = e.Nombre + " " + e.ApellidoPaterno,
                                   Colegio = co.Nombre,
                                   Curso = cu.Nombre,
                                   t.Estado
                               }).ToListAsync();

            return Ok(tests);
        }

        [HttpPost]
        public async Task<IActionResult> PostTest(string codigo, string estudiante_ci, string colegio_codigo, int curso_id, int usuario_id = 1) 
        {
            var comprobando_test = await (from ts in _testContext.Tests
                                          where ts.Codigo == codigo
                                          select ts).FirstOrDefaultAsync();

            if(comprobando_test != null)
            {
                return BadRequest("Codigo de test ya creado");
            }

            var estudiante = await (from est in _testContext.Estudiantes
                                    where est.Ci == estudiante_ci
                                    select est).FirstOrDefaultAsync();

            if (estudiante == null)
            {
                return BadRequest("Ci del estudiante no registrado");
            }

            var colegio = await (from col in _testContext.Colegios
                                 where col.Codigo == colegio_codigo
                                 select col).FirstOrDefaultAsync();

            if(colegio == null)
            {
                return BadRequest("Codigo del colegio no registrado");
            }

            var nuevo_test = new Test()
            {
                Codigo = codigo,
                Estudiante_ci = estudiante.Id,
                Colegio_id = colegio.Id,
                Curso_id = curso_id,
                Usuario_id = usuario_id
            };

            await _testContext.Tests.AddAsync(nuevo_test);
            await _testContext.SaveChangesAsync();

            return Ok("Test creado con exito");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTest(string codigo) 
        {
            var existencia_test = await (from ts in _testContext.Tests
                                         where ts.Codigo == codigo
                                         select ts).FirstOrDefaultAsync();

            if(existencia_test == null)
            {
                return BadRequest("Test no fue registrado");
            }

            existencia_test.Estado = false;

            await _testContext.SaveChangesAsync();

            return Ok("Test eliminado con exito");
        }

        [HttpPut]
        public async Task<IActionResult> PutTest(string codigo, string estudiante_ci, string colegio_codigo, int curso_id, bool estado, int usuario_id = 1)
        {
            var existencia_test = await (from ts in _testContext.Tests
                                         where ts.Codigo == codigo
                                         select ts).FirstOrDefaultAsync();

            if(existencia_test == null)
            {
                return BadRequest("Test no fue registrado");
            }

            var estudiante = await (from est in _testContext.Estudiantes
                                    where est.Ci == estudiante_ci
                                    select est).FirstOrDefaultAsync();

            if (estudiante == null)
            {
                return BadRequest("Ci del estudiante no registrado");
            }

            var colegio = await (from col in _testContext.Colegios
                                 where col.Codigo == colegio_codigo
                                 select col).FirstOrDefaultAsync();

            if (colegio == null)
            {
                return BadRequest("Codigo del colegio no registrado");
            }

            existencia_test.Estudiante_ci = estudiante.Id;
            existencia_test.Colegio_id = colegio.Id;
            existencia_test.Curso_id = curso_id;
            existencia_test.Usuario_id = usuario_id;
            existencia_test.Estado = estado;

            await _testContext.SaveChangesAsync();

            return Ok("Test actualizado con exito");
        }
    }
}
