using Microsoft.EntityFrameworkCore;

namespace Quanda.Models
{
    public class QuandaDbContext: DbContext
    {
        public QuandaDbContext(DbContextOptions<QuandaDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Question> Questions { get; set; }
    }
}