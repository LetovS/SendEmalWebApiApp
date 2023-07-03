using Microsoft.EntityFrameworkCore;

namespace SendEmalWebApi.Data
{
    public class SenderContext : DbContext
    {
        public SenderContext(DbContextOptions<SenderContext> opt) : base (opt)
        {
            
        }
    }
}
