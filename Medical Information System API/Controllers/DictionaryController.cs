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

        public DictionaryController(ILogger<DictionaryController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("speciality")]
        public async Task<IActionResult> GetSpecialities(string name = "", int page = 1, int size = 5)
        {
            var consultationList = await _context.SpecialitiesList.OrderBy(c => c.Name).Where(c => c.Name.ToLower().Contains(name.ToLower()))
                    .Skip((page - 1) * size).Take(size).ToListAsync();

            var amountOfRecords = await _context.SpecialitiesList.CountAsync();
            var count = (int) Math.Ceiling(amountOfRecords * 1.0 / size);

            var answer = new SpecialitiesPagedListModel(consultationList, new PageInfoModel(size, count, page));

            return Ok(answer);
        }

        [HttpGet("icd10")]
        public async Task<IActionResult> GetDiagnoses()
        {
            return Ok();
        }

        [HttpGet("icd-10/roots")]
        public async Task<IActionResult> GetRootICDElements()
        {
            //var roots = await _context.Icd10.Where(x => x.Id == Guid.Empty).ToListAsync();

            //var res = new List<Icd10RecordModel>();
            //foreach (var root in roots)
            //{
            //    res.Add(new Icd10RecordModel(root));
            //}

            //return Ok(res);

            return Ok();
        }
    }
}
