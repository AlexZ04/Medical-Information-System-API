using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : Controller
    {
        private readonly DataContext _context;

        public ReportController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("icdrootsreport")]
        public async Task<IActionResult> GetReport([FromQuery, Required] DateTime start, [FromQuery, Required] DateTime end,
            [FromQuery] List<Guid>? icdRoots, [FromBody] IcdRootsReportModel aaa)
        {

            if (icdRoots == null)
            {
                icdRoots = await _context.Icd10.Where(i => i.ParentId == null).Select(r => r.Id).ToListAsync();
            }
            else
            {
                foreach (var icdRootId in icdRoots)
                {
                    var root = _context.Icd10.Find(icdRootId);
                    if (root == null || root.ParentId != null) return BadRequest();
                }
            }

            return Ok();
        }
    }
}
