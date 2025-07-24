using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TestCarreraController : Controller
    {
        private readonly TestContext _testContext;

        public TestCarreraController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetIdTestCarrera(int test_id, int carrera_id)
        {
            var test_carrera = await (from tsc in _testContext.TestCarreras
                                      where tsc.Test_id == test_id && tsc.Carrera_id == carrera_id
                                      select tsc).FirstOrDefaultAsync();

            return Ok(test_carrera);
        }

        [HttpPost]
        public async Task<IActionResult> PostTestCarrera(string codigo, string test_codigo, int carrera_id) 
        { 
            var existencia_test_carrera = await (from tsc in _testContext.TestCarreras
                                                 where tsc.Codigo == codigo
                                                 select tsc).FirstOrDefaultAsync();

            if(existencia_test_carrera == null)
            {
                return BadRequest("Codigo del test de carrera no fue registrado");
            }

            var test = await (from ts in _testContext.Tests
                              where ts.Codigo == test_codigo
                              select ts).FirstOrDefaultAsync();

            if(test == null)
            {
                return BadRequest("Test no fue registrado");
            }

            var nuevo_test_carrera = new TestCarrera()
            {
                Codigo = codigo,
                Test_id = test.Id,
                Carrera_id = carrera_id
            };

            await _testContext.TestCarreras.AddAsync(nuevo_test_carrera);
            await _testContext.SaveChangesAsync();

            return Ok("Test carrera creado con exito");
        }

        [HttpPut]
        public async Task<IActionResult> PutTestCarrera(string codigo, string test_codigo, int carrera_id) 
        {
            var existencia_test_carrera = await (from tsc in _testContext.TestCarreras
                                                 where tsc.Codigo == codigo
                                                 select tsc).FirstOrDefaultAsync();

            if(existencia_test_carrera == null)
            {
                return BadRequest("Test carrera no fue registrado");
            }

            var test = await (from ts in _testContext.Tests
                              where ts.Codigo == test_codigo
                              select ts).FirstOrDefaultAsync();

            if (test == null)
            {
                return BadRequest("Test no fue registrado");
            }

            existencia_test_carrera.Test_id = test.Id;
            existencia_test_carrera.Carrera_id = carrera_id;
            
            await _testContext.SaveChangesAsync();

            return Ok("Test carrera actualizado con exito");
        }
    }
}
