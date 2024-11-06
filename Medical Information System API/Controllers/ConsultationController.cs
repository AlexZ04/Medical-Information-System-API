using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/consultation")]
    public class ConsultationController : Controller
    {
        private readonly DataContext _context;

        public ConsultationController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of medical inspections for consultation
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetInspections([FromQuery] bool grouped, [FromQuery] List<Guid> icdRoots,
            [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            loginnedDoctor.Password = "";

            var inspList = _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .Where(x => x.Doctor.Speciality == loginnedDoctor.Speciality);

            if (icdRoots.Count > 0) inspList = inspList.Where(x => x.Diagnoses.Any(d => 
            icdRoots.Contains(_context.GetIcdParent(d.Record.Id).Id) &&
            d.Type == DiagnosisType.Main && d.Record.ParentId == null));

            if (grouped)
            {
                inspList = inspList.
                    OrderBy(x => x.Group).ThenBy(x => x.CreateTime);
            }

            inspList = inspList.Skip((page - 1) * size).Take(size);
            var inspections = await inspList.ToListAsync();

            List<InspectionPreviewModel> list = new List<InspectionPreviewModel>();
            bool hasChain = false, hasNested = false;

            foreach (var inspection in inspections)
            {
                var childInsp = await _context.Inspections.FirstOrDefaultAsync(x => x.PreviousInspectionId == inspection.Id);

                if (childInsp != null)
                {
                    hasNested = true;

                    if (inspection.PreviousInspectionId != null) hasChain = false;
                    else hasChain = true;
                }
                else
                {
                    hasChain = false;
                    hasNested = false;
                }

                var previewModel = new InspectionPreviewModel(inspection, hasChain, hasNested);

                list.Add(previewModel);
            }

            var amount = await _context.Inspections.CountAsync();
            var count = (int)Math.Ceiling(amount * 1.0 / size);

            var res = new InspectionPagedListModel(list, new PageInfoModel(size, count, page));

            return Ok(res);
        }

        /// <summary>
        /// Get concrete consultation
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetConcreteConsultation(Guid id)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var cons = await _context.Consultations
                .Include(c => c.Speciality)
                .Include(c => c.Comments).ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (cons == null) return BadRequest();

            return Ok(new ConsultationModel(cons));
        }

        /// <summary>
        /// Add comment to concrete consultation
        /// </summary>
        [HttpPost("{id}/comment")]
        [Authorize]
        public async Task<IActionResult> AddComment(Guid id, [FromBody] CommentCreateModel comment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            var createComment = new Comment(comment, loginnedDoctor);

            _context.Comments.Add(createComment);
            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok();
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        [HttpPut("comment/{id}")]
        [Authorize]
        public async Task<IActionResult> EditComment(Guid id, [FromBody] InspectionCommentCreateModel newComment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            var comment = await _context.Comments.FindAsync(id);

            if (comment == null) return BadRequest();

            if (comment.Author.Id != new Guid(userId)) return Forbid();

            comment.Content = newComment.Context;
            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok();
        }
    }
}
