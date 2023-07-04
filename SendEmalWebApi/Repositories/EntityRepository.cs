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
        public void Create(EntityDB model)
        {
            _context.RequestModels.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<EntityDB>> GetAll()
        {
            var result = await _context.RequestModels
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
            return result;
        }
    }
}
