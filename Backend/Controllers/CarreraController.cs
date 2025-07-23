using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : Controller
    {
        private readonly TestContext _testContext;
        public CarreraController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetIdCarrera(int id_aptitud)
        {
            var carreras = await (from mt in _testContext.Carreras
                                  where mt.Aptitud_id == id_aptitud
                                  select mt).ToListAsync();

            return Ok(carreras);
        }
    }
}
