using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCarreraController : Controller
    {
        private readonly TestContext _testContext;

        public TestCarreraController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCarrera(int id_test)
        {
            var carreras = await (from ct in _testContext.CarreraTests
                                      join t in _testContext.Tests on ct.Test_id equals t.Id
                                      join c in _testContext.Carreras on ct.Carrera_id equals c.Id
                                      where t.Id == id_test
                                      select new
                                      {
                                          Id = c.Id,
                                          Carreras = c.Nombre
                                      }).ToListAsync();

            return Ok(carreras);
        }

        [HttpPost]
        public async Task<IActionResult> PostTestCarrera(string test_codigo, int carrera_id)
        {
            var test = await (from ts in _testContext.Tests
                              where ts.Codigo == test_codigo
                              select ts).FirstOrDefaultAsync();

            if (test == null)
            {
                return BadRequest("Test no fue registrado");
            }

            var nuevo_test_carrera = new CarreraTest()
            {
                Test_id = test.Id,
                Carrera_id = carrera_id
            };

            await _testContext.CarreraTests.AddAsync(nuevo_test_carrera);
            await _testContext.SaveChangesAsync();

            return Ok("Test carrera creado con exito");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCTest(int test_id, int carrera_id) 
        {
            var test = await (from ts in _testContext.CarreraTests
                              where ts.Test_id == test_id && ts.Carrera_id == carrera_id
                              select ts).FirstOrDefaultAsync();

            if (test == null)
            {
                return NotFound("Test o carrera no coinciden");
            }

            _testContext.CarreraTests.Remove(test);
            await _testContext.SaveChangesAsync();

            return Ok("Eliminacion correcta");
        }
    }
}
