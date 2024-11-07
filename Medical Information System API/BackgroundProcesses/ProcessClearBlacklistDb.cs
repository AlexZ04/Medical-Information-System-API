using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Medical_Information_System_API.BackgroundProcesses
{
    [DisallowConcurrentExecution]
    public class ProcessClearBlacklistDb : IJob
    {
        private readonly DataContext _dbContext;
        private readonly ILogger<ProcessClearBlacklistDb> _logger;

        public ProcessClearBlacklistDb(DataContext dbContext, ILogger<ProcessClearBlacklistDb> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var currentTime = DateTime.Now.ToUniversalTime();

            List<BlacklistToken> tokens = await _dbContext.BlacklistTokens
                .Where(t => (currentTime - t.AddTime).TotalHours >= 1)
                .ToListAsync();

            _dbContext.BlacklistTokens.RemoveRange(tokens);

            await _dbContext.SaveChangesAsync();
        }
    }
}
