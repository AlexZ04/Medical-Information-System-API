﻿using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<ReportController> _logger;

        public ReportController(DataContext context, ILogger<ReportController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get a report on patients visits based on ICD-10 roots for a specified time interval
        /// </summary>
        [HttpGet("icdrootsreport")]
        [Authorize]
        public async Task<IActionResult> GetReport([FromQuery, Required] DateTime start, [FromQuery, Required] DateTime end,
            [FromQuery] List<Guid> icdRoots)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            List<string> icdRootsCodes = new List<string>();

            if (icdRoots.Count() == 0)
            {
                icdRootsCodes = await _context.Icd10.Where(i => i.ParentId == null).OrderBy(r => r.Code).Select(r => r.Code).ToListAsync();
            }
            else
            {
                foreach (var icdRootId in icdRoots)
                {
                    var root = _context.Icd10.Find(icdRootId);
                    if (root == null || root.ParentId != null) return BadRequest();
                    if (root != null) icdRootsCodes.Add(root.Code);
                }
            }

            Dictionary<string, int> rootsVisiting = new Dictionary<string, int>();
            Dictionary<string, int> dictSample = new Dictionary<string, int>();

            foreach (var icdRootCode in icdRootsCodes)
            {
                rootsVisiting.Add(icdRootCode, 0);
                dictSample.Add(icdRootCode, 0);
            }

            var records = new List<IcdRootsReportRecordModel>();
            var filters = new IcdRootsReportFiltersModel(start, end, icdRootsCodes);

            List<Guid> usedPatients = new List<Guid>();

            var inspList = await _context.Inspections
                .Include(i => i.Patient).Include(i => i.Doctor)
                .Include(i => i.Diagnoses).ThenInclude(d => d.Record)
                .OrderBy(i => i.Patient.Name)
                .Where(i => i.Date >= start && i.Date <= end).ToListAsync();

            foreach (var insp in inspList) { 
                if (!usedPatients.Contains(insp.Patient.Id))
                {
                    usedPatients.Add(insp.Patient.Id);
                    records.Add(new IcdRootsReportRecordModel(insp.Patient.Name, insp.Patient.Birthday, insp.Patient.Gender,
                        dictSample.ToDictionary(entry => entry.Key, entry => entry.Value)));
                }

                var diagnose = insp.Diagnoses.Where(d => d.Type == DiagnosisType.Main).SingleOrDefault();

                if (diagnose == null) return NotFound();

                try
                {
                    string rootCode = _context.GetIcdParent(diagnose.Record.Id).Code;

                    if (rootCode != null && icdRootsCodes.Contains(rootCode))
                    {
                        records[usedPatients.IndexOf(insp.Patient.Id)].VisitByRoot[rootCode]++;
                        rootsVisiting[rootCode]++;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }

            var result = new IcdRootsReportModel(filters, records, rootsVisiting);

            return Ok(result);
        }
    }
}
