using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Data
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class SenderContext : DbContext
    {
        /// <summary>
        /// Логи.
        /// </summary>
        public DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Адреса электронной почты.
        /// </summary>
        public DbSet<Email> Emails { get; set; }
        /// <summary>
        /// Инициализация контекста базы данных.
        /// </summary>
        /// <param name="opt">Опции контекста БД.</param>
        public SenderContext(DbContextOptions<SenderContext> opt) : base (opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Log>()
                .HasData(new Log
                {
                    Id = 1,
                    Subject = "My first email",
                    Body = "Hello my friends",
                    FieledMessage = string.Empty
                }
                );
            modelBuilder.Entity<Email>()
               .HasData(new Email { Id = 1, EmailAddress = "test1@mail.ru", LogId = 1 }, new Email { Id = 2, EmailAddress = "test2@gmail.com", LogId = 1 });
        }
    }
}
