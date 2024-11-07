using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System.Data;

namespace Medical_Information_System_API.BackgroundProcesses
{
    public class ProcessEmails : IJob
    {
        private readonly ILogger<ProcessEmails> _logger;
        private readonly DataContext _dbContext;
        
        public ProcessEmails(ILogger<ProcessEmails> logger, DataContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await CheckInspections();
            await CheckEmails();
        }

        private async Task CheckInspections()
        {
            var potentialInspiredInspections = _dbContext.Inspections
                .Where(i => i.NextVisitDate != null &&
                    (DateTime.Now.ToUniversalTime() - (DateTime)i.NextVisitDate).TotalHours >= 1);

            potentialInspiredInspections = potentialInspiredInspections
                .Where(i => !_dbContext.Inspections.Any(i => i.PreviousInspectionId == i.Id));

            potentialInspiredInspections = potentialInspiredInspections
                .Where(i => !_dbContext.InspiredInspections.Any(ii => ii.Id == i.Id));

            var potentialList = await potentialInspiredInspections.ToListAsync();

            _logger.LogError(potentialList.Count.ToString());

            foreach (var potential in potentialList)
            {
                _dbContext.InspiredInspections.Add(new InspiredInspection(potential));
            }

            await _dbContext.SaveChangesAsync();
        }

        private async Task CheckEmails()
        {
            var queueToSend = await _dbContext.InspiredInspections
                .Where(ii => ii.SendedEmail == false)
                .ToListAsync();

            foreach (var inspiredInsp in queueToSend)
            {
                await SendEmail(inspiredInsp);
                //inspiredInsp.SendedEmail = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task SendEmail(InspiredInspection inspectionData)
        {

        }
    }
}
