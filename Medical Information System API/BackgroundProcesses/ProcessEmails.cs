using Medical_Information_System_API.Data;
using Quartz;

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
            _logger.LogError("aa");
        }
    }
}
