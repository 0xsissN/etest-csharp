using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegioController : Controller
    {
        private readonly TestContext _testContext;

        public ColegioController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetColegio()
        {
            var colegios = await (from col in _testContext.Colegios
                                  select col).ToListAsync();

            return Ok(colegios);
        }

        [Authorize (Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostColegio(Colegio colegio)
        {
            var comprobando_colegio = await (from col in _testContext.Colegios
                                             where col.Codigo == colegio.Codigo
                                             select col).FirstOrDefaultAsync();

            if(comprobando_colegio != null)
            {
                return BadRequest("Codigo del colegio ya registrado");
            }

            var nuevo_colegio = new Colegio()
            {
                Codigo = colegio.Codigo,
                Nombre = colegio.Nombre,
                Direccion = colegio.Direccion
            };

            await _testContext.Colegios.AddAsync(nuevo_colegio);
            await _testContext.SaveChangesAsync();

            return Ok("Colegio creado con exito");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteColegio(string codigo)
        {
            var existencia_colegio = await (from col in _testContext.Colegios
                                            where col.Codigo == codigo
                                            select col).FirstOrDefaultAsync();

            if(existencia_colegio == null)
            {
                return NotFound("El codigo del colegio no fue registrado");
            }

            existencia_colegio.Estado = false;

            await _testContext.SaveChangesAsync();

            return Ok("Colegio eliminado con exito");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> PutColegio(Colegio colegio)
        {
            var existencia_colegio = await (from col in _testContext.Colegios
                                            where col.Codigo == colegio.Codigo
                                            select col).FirstOrDefaultAsync();

            if(existencia_colegio == null)
            {
                return NotFound("El codigo del colegio no fue registrado");
            }

            existencia_colegio.Nombre = colegio.Nombre; 
            existencia_colegio.Direccion = colegio.Direccion;
            existencia_colegio.Estado = colegio.Estado;

            await _testContext.SaveChangesAsync();

            return Ok("Colegio actualizado con exito");
        }
    }
}
