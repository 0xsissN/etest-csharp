using Backend.Data;
using Backend.Models;
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

        [HttpPost]
        public async Task<IActionResult> PostColegio(string codigo, string nombre, string direccion)
        {
            var comprobando_colegio = await (from col in _testContext.Colegios
                                             where col.Codigo == codigo
                                             select col).FirstOrDefaultAsync();

            if(comprobando_colegio != null)
            {
                return BadRequest("Codigo del colegio ya registrado");
            }

            var nuevo_colegio = new Colegio()
            {
                Codigo = codigo,
                Nombre = nombre,
                Direccion = direccion
            };

            await _testContext.Colegios.AddAsync(nuevo_colegio);
            await _testContext.SaveChangesAsync();

            return Ok("Colegio creado con exito");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteColegio(string codigo)
        {
            var existencia_colegio = await (from col in _testContext.Colegios
                                            where col.Codigo == codigo
                                            select col).FirstOrDefaultAsync();

            if(existencia_colegio == null)
            {
                return BadRequest("El codigo del colegio no fue registrado");
            }

            existencia_colegio.Estado = false;

            await _testContext.SaveChangesAsync();

            return Ok("Colegio eliminado con exito");
        }

        [HttpPut]
        public async Task<IActionResult> PutColegio(string codigo, string nombre, string direccion)
        {
            var existencia_colegio = await (from col in _testContext.Colegios
                                            where col.Codigo == codigo
                                            select col).FirstOrDefaultAsync();

            if(existencia_colegio == null)
            {
                return BadRequest("El codigo del colegio no fue registrado");
            }

            existencia_colegio.Nombre = nombre; 
            existencia_colegio.Direccion = direccion;

            await _testContext.SaveChangesAsync();

            return Ok("Colegio actualizado con exito");
        }
    }
}
