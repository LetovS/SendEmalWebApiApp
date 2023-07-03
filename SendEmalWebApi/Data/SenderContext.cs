using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Data
{
    public class SenderContext : DbContext
    {
        public DbSet<EntityDB> RequestModels { get; set; }
        public DbSet<Email> Emails { get; set; }
        public SenderContext(DbContextOptions<SenderContext> opt) : base (opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>()
                .HasData(new Email { Id = 1, EmailAddress = "test1@mail.ru" }, new Email { Id = 2, EmailAddress = "test2@gmail.com" });


            modelBuilder.Entity<EntityDB>()
                .HasData(new EntityDB
                {
                    Id = 1,
                    Subject = "My first email",
                    Body = "Hello my friends",
                    RecipientId = 1,
                    Result = Result.OK,
                    FieledMessage = string.Empty
                },
                new EntityDB
                {
                    Id = 2,
                    Subject = "My second email",
                    Body = "Hello my friends #2",
                    RecipientId = 2,
                    Result = Result.Failed,
                    FieledMessage = "Throw exception somewhere.."
                });
        }
    }
}
