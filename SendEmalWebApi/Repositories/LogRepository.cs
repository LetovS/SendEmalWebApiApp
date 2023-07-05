using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Data;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Repositories
{
    /// <summary>
    /// Репозитарий логов.
    /// </summary>
    public class LogRepository : IRepository<Log>
    {
        private readonly SenderContext _context;
        /// <summary>
        /// Инициализация репозитория логов.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public LogRepository(SenderContext context)
        {
            _context = context;
        }
        /// <inheritdoc/>
        public async Task Add(Log model)
        {
            _context.Logs.Add(model);
            await _context.SaveChangesAsync();
        }
        /// <inheritdoc/>
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
