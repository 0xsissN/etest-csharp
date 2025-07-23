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
    }
}
