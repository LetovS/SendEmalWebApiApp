using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Data;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Repositories
{
    public class EntityRepository : IRepository<EntityDB>
    {
        private readonly SenderContext _context;

        public EntityRepository(SenderContext context)
        {
            _context = context;
        }
        public EntityDB Create(EntityDB model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EntityDB>> GetAll()
        {
            return await _context.RequestModels.Include(x => x.Recipient)
                .Select(x => new EntityDB
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    FieledMessage = x.FieledMessage,
                    Recipient = x.Recipient,
                    Body = x.Body,
                    Result = x.Result
                })
                .ToListAsync();
        }
    }
}
