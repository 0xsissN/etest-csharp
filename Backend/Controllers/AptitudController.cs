using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AptitudController : Controller
    {
        private readonly TestContext _testContext;

        public AptitudController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAptitude()
        {
            var aptitudes = await (from ap in _testContext.Aptitudes
                                   select ap).ToListAsync();

            return Ok(aptitudes);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetAptitudByID(int id_test)
        {
            var aptitudes = await (from ct in _testContext.CarreraTests
                                   join t in _testContext.Tests on ct.Test_id equals t.Id
                                   join c in _testContext.Carreras on ct.Carrera_id equals c.Id
                                   join a in _testContext.Aptitudes on c.Aptitud_id equals a.Id
                                   where t.Id == id_test
                                   select new
                                   {
                                       Carreras = a.Nombre
                                   }).Distinct().ToListAsync();

            return Ok(aptitudes);
        }
    }
}
