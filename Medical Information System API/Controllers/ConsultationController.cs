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
        private readonly ILogger<ConsultationController> _logger;

        public ConsultationController(DataContext context, ILogger<ConsultationController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Get a list of medical inspections for consultation
        /// </summary>
        /// <response code="200">Inspections for consultation list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(InspectionPagedListModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetInspections([FromQuery] bool grouped, [FromQuery] List<Guid> icdRoots,
            [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return NotFound();

            if (page <= 0 || size <= 0) return BadRequest(new ResponseModel("Error", "Invalid value for pagination"));

            loginnedDoctor.Password = "";

            foreach (var icdRoot in icdRoots)
            {
                var foundRoot = _context.Icd10.Find(icdRoot);
                if (foundRoot == null || foundRoot.ParentId != null) return BadRequest(new ResponseModel("Error", "Invalid ICd-10 roots"));
            }


            var inspList = _context.Inspections
                .Include(i => i.Patient).Include(i => i.Doctor)
                .Include(i => i.Diagnoses).ThenInclude(d => d.Record)
                .Include(i => i.Consultations).ThenInclude(c => c.Comments)
                .Where(x => x.Doctor.Speciality == loginnedDoctor.Speciality);

            try
            {
                if (icdRoots.Count > 0) inspList = inspList.Where(x => x.Diagnoses.Any(d =>
                    icdRoots.Contains(_context.GetIcdParent(d.Record.Id).Id) &&
                    d.Type == DiagnosisType.Main && d.Record.ParentId == null));
            }
            catch (ObjectDisposedException ex)
            {
                _logger.LogError(ex.ToString());
            }

            if (grouped)
            {
                inspList = inspList.
                    OrderBy(i => i.Group).ThenBy(i => i.CreateTime);
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

            if (page > count && count > 0) return BadRequest(new ResponseModel("Error", "Page number must be less than pages count"));

            var res = new InspectionPagedListModel(list, new PageInfoModel(size, count, page));

            return Ok(res);
        }


        /// <summary>
        /// Get concrete consultation
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Consultation or parent comment not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ConsultationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
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

            if (cons == null) return NotFound();

            cons.Comments = cons.Comments.OrderBy(c => c.CreateTime).ToList();

            return Ok(new ConsultationModel(cons));
        }


        /// <summary>
        /// Add comment to concrete consultation
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not found</response>
        /// <response code="406">User doesn't have add comment to consultation 
        /// (unsuitable specialty and not the inspection author)</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(GuidResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("{id}/comment")]
        [Authorize]
        public async Task<IActionResult> AddComment(Guid id, [FromBody] CommentCreateModel comment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return NotFound();

            var consultation = _context.Consultations
                .Include(c => c.Comments)
                .Include(c => c.Speciality)
                .FirstOrDefault(c => c.Id == id);

            if (consultation == null) return NotFound(new ResponseModel("Error", "Consultation not found"));

            if (consultation.Speciality.Id != loginnedDoctor.Speciality &&
                consultation.AuthorId != new Guid(userId)) return StatusCode(StatusCodes.Status406NotAcceptable);

            var parentComment = _context.Comments.Find(comment.ParentId);
            if (parentComment == null) return NotFound(new ResponseModel("Error", "Parent comment not found"));

            if (!consultation.Comments.Contains(parentComment)) 
                return BadRequest(new ResponseModel("Error", "Parent comment is not from current consultation"));

            var createComment = new Comment(comment, loginnedDoctor);

            _context.Comments.Add(createComment);
            consultation.Comments.Add(createComment);
            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok(new GuidResponseModel { Id = createComment.Id });
        }


        /// <summary>
        /// Edit comment
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Comment not found</response>
        /// <response code="406">User is not the author of the comment</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("comment/{id}")]
        [Authorize]
        public async Task<IActionResult> EditComment(Guid id, [FromBody] InspectionCommentCreateModel newComment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            var comment = await _context.Comments
                .Include(c => c.Author)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null) return NotFound(new ResponseModel("Error", "Comment not found"));

            if (comment.Author.Id != new Guid(userId)) return StatusCode(StatusCodes.Status406NotAcceptable);

            comment.Content = newComment.Context;
            comment.ModifiedDate = DateTime.Now.ToUniversalTime();
            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok(new ResponseModel("Success", "Comment edited"));
        }
    }
}
