using Microsoft.AspNetCore.Mvc;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : Controller
    {
        [HttpGet("icdrootsreport")]
        public async Task<IActionResult> GetReport()
        {

            return Ok();
        }
    }
}
