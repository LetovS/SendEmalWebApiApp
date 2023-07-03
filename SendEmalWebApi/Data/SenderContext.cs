using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Data
{
    public class SenderContext : DbContext
    {
        public DbSet<RequestModel> RequestModels { get; set; }
        public SenderContext(DbContextOptions<SenderContext> opt) : base (opt)
        {
            
        }
    }
}
