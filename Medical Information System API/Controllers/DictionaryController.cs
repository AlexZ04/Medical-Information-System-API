using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.IcdTree;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;

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


        /// <summary>
        /// Get spetialities list
        /// </summary>
        /// <response code="200">Specialties paged list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(SpecialitiesPagedListModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("speciality")]
        public async Task<IActionResult> GetSpecialities([FromQuery] string? name, [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            if (page <= 0 || size <= 0) return BadRequest(new ResponseModel("Error", "Invalid value for pagination"));

            if (name == null) name = "";

            var consultationList = await _context.SpecialitiesList
                .OrderBy(s => s.Name)
                .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                .Skip((page - 1) * size).Take(size)
                .ToListAsync();

            var amountOfRecords = await _context.SpecialitiesList
                .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                .CountAsync();
            var count = (int) Math.Ceiling(amountOfRecords * 1.0 / size);

            if (page > count) return BadRequest(new ResponseModel("Error", "Page number must be less than pages count"));

            var answer = new SpecialitiesPagedListModel(consultationList, new PageInfoModel(size, count, page));

            return Ok(answer);
        }


        /// <summary>
        /// Search for diagnoses in ICD-10 dictionary
        /// </summary>
        /// <response code="200">Specialties paged list retrieved</response>
        /// <response code="400">Some fields in requests are invalid</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(Icd10SearchModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("icd10")]
        public IActionResult GetDiagnoses([FromQuery] string? request, [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            if (page <= 0 || size <= 0) return BadRequest(new ResponseModel("Error", "Invalid value for pagination"));

            bool isCode = false;

            if (request == null) request = "";

            request = request.ToLower();

            if (request.Length > 0)
            {
                if (request[0] >= 'a' && request[0] <= 'z')
                {
                    isCode = true;
                }
                else if (request[0] >= 'а' && request[0] <= 'я')
                {
                    isCode = false;
                }
            }

            var records = new List<Icd10Record>();
            if (isCode)
            {
                records = IcdDataManager.CodeTree.GetChildren(request);
            }
            else
            {
                records = IcdDataManager.NameTree.GetChildren(request);
            }

            var amountOfDiagnoses = records.Count;
            records = records.Skip((page - 1) * size).Take(size).ToList();

            var diagnosesList = new List<Icd10RecordModel>();
            foreach (var record in records)
            {
                diagnosesList.Add(new Icd10RecordModel { Code = record.Code, Id = record.Id, CreateTime = record.CreateTime, Name = record.Name });
            }

            var count = (int)Math.Ceiling(amountOfDiagnoses * 1.0 / size);

            if (page > count && count > 0) return BadRequest(new ResponseModel("Error", "Page number must be less than pages count"));

            var answer = new Icd10SearchModel(diagnosesList, new PageInfoModel(size, count, page));

            return Ok(answer);
        }


        /// <summary>
        /// Get root ICD-10 elements
        /// </summary>
        /// <response code="200">Root ICD-10 elements retrieved</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<Icd10RecordModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("icd-10/roots")]
        public IActionResult GetRootICDElements()
        {
            var roots = IcdDataManager.Roots.OrderBy(r => r.Code);

            var res = new List<Icd10RecordModel>();
            foreach (var root in roots)
            {
                res.Add(new Icd10RecordModel { Code = root.Code, Id = root.Id, CreateTime = root.CreateTime, Name = root.Name });
            }

            return Ok(res);
        }
    }
}
