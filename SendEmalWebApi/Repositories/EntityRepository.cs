using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Data;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Repositories
{
    public class EntityRepository : IRepository<Log>
    {
        private readonly SenderContext _context;

        public EntityRepository(SenderContext context)
        {
            _context = context;
        }
        public async Task Create(Log model)
        {
            _context.Logs.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Log>> GetAll()
        {
            var result = await _context.Logs
                .Select(x => new Log
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    FieledMessage = x.FieledMessage,
                    Recipient = x.Recipient,
                    Body = x.Body,
                    Result = x.Result
                })
                .ToListAsync();
            return result;
        }
    }
}
