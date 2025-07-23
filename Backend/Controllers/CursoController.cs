using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly TestContext _testContext;

        public CursoController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurso()
        {
            var cursos = await (from c in _testContext.Cursos
                                select c).ToListAsync();

            return Ok(cursos);
        }
    }
}
