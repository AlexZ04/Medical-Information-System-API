using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/dictionary")]
    public class DictionaryController : Controller
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public DictionaryController(ILogger<DictionaryController> logger, DataContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("speciality")]
        public async Task<IActionResult> GetSpecialities([FromQuery] string name = "", [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var consultationList = await _context.SpecialitiesList.OrderBy(c => c.Name).Where(c => c.Name.ToLower().Contains(name.ToLower()))
                    .Skip((page - 1) * size).Take(size).ToListAsync();

            var amountOfRecords = await _context.SpecialitiesList.Where(c => c.Name.ToLower().Contains(name.ToLower())).CountAsync();
            var count = (int) Math.Ceiling(amountOfRecords * 1.0 / size);

            var answer = new SpecialitiesPagedListModel(consultationList, new PageInfoModel(size, count, page));

            return Ok(answer);
        }

        [HttpGet("icd10")]
        public async Task<IActionResult> GetDiagnoses([FromQuery] string request = "", [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var records = await _context.Icd10.OrderBy(d => d.Code).Where(d => d.Name.ToLower().StartsWith(request.ToLower()) ||
                d.Code.ToLower().Contains(request.ToLower()))
                .Skip((page - 1) * size).Take(size).ToListAsync();

            var diagnosesList = new List<Icd10RecordModel>();
            foreach (var record in records)
            {
                diagnosesList.Add(new Icd10RecordModel { Code = record.Code, Id = record.Id, CreateTime = record.CreateTime, Name = record.Name });
            }

            var amountOfDiagnoses = await _context.Icd10.Where(d => d.Name.ToLower().StartsWith(request.ToLower()) ||
                d.Code.ToLower().Contains(request.ToLower())).CountAsync();
            var count = (int)Math.Ceiling(amountOfDiagnoses * 1.0 / size);

            var answer = new Icd10SearchModel(diagnosesList, new PageInfoModel(size, count, page));

            return Ok(answer);
        }

        [HttpGet("icd-10/roots")]
        public async Task<IActionResult> GetRootICDElements()
        {
            var roots = await _context.Icd10.Where(x => x.ParentId == Guid.Empty).OrderBy(x => x.Code).ToListAsync();

            var res = new List<Icd10RecordModel>();
            foreach (var root in roots)
            {
                res.Add(new Icd10RecordModel { Code = root.Code, Id = root.Id, CreateTime = root.CreateTime, Name = root.Name });
            }

            return Ok(res);
        }
    }
}
