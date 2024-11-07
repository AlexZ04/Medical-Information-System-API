using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace Medical_Information_System_API.BackgroundProcesses
{
    public class ProcessEmails : IJob
    {
        private readonly ILogger<ProcessEmails> _logger;
        private readonly DataContext _dbContext;
        private readonly MailAddress _from = new MailAddress(MailData.EMAIL, "Medical MEGA Hospital");
        
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
                .Include(i => i.Patient).Include(i => i.Doctor)
                .Include(i => i.Diagnoses).ThenInclude(d => d.Record)
                .Include(i => i.Consultations).ThenInclude(c => c.Comments)
                .Include(i => i.Consultations).ThenInclude(c => c.Speciality)

                .Where(i => i.NextVisitDate != null &&
                    (DateTime.Now.ToUniversalTime() - (DateTime)i.NextVisitDate).TotalHours >= 1);

            potentialInspiredInspections = potentialInspiredInspections
                .Where(i => !_dbContext.Inspections.Any(i => i.PreviousInspectionId == i.Id));

            potentialInspiredInspections = potentialInspiredInspections
                .Where(i => !_dbContext.InspiredInspections.Any(ii => ii.Id == i.Id));

            var potentialList = await potentialInspiredInspections.ToListAsync();

            foreach (var potential in potentialList)
            {
                _dbContext.InspiredInspections.Add(new InspiredInspection(potential));
            }

            await _dbContext.SaveChangesAsync();
        }

        private async Task CheckEmails()
        {
            var queueToSend = await _dbContext.InspiredInspections
                .Include(i => i.Inspection).ThenInclude(i => i.Patient)
                .Include(i => i.Inspection).ThenInclude(i => i.Doctor)
                .Include(i => i.Inspection).ThenInclude(i => i.Diagnoses).ThenInclude(d => d.Record)

                .Include(i => i.Inspection).ThenInclude(i => i.Consultations).ThenInclude(c => c.Comments)
                .Include(i => i.Inspection).ThenInclude(i => i.Consultations).ThenInclude(c => c.Speciality)

                .Where(ii => ii.SendedEmail == false)
                .ToListAsync();

            foreach (var inspiredInsp in queueToSend)
            {
                await SendEmail(inspiredInsp);
                inspiredInsp.SendedEmail = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task SendEmail(InspiredInspection inspectionData)
        {
            MailAddress to = new MailAddress(inspectionData.Inspection.Doctor.Email);
            MailMessage message = new MailMessage(_from, to);

            message.Subject = "Пропущенный осмотр!";
            message.Body = EmailManager.MakeEmailText(inspectionData);

            message.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Timeout = 10000;
            smtp.Credentials = new NetworkCredential(MailData.EMAIL, MailData.APP_PASSWORD);

            await smtp.SendMailAsync(message);
        }
    }
}
