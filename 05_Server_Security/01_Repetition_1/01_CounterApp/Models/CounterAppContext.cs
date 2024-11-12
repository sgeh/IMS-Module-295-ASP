using Microsoft.EntityFrameworkCore;

namespace Bwz.Rappi.Models
{
    public class CounterAppContext : DbContext
    {
        public CounterAppContext(DbContextOptions<CounterAppContext> options)
            : base(options) { }
        public DbSet<Log> Logs { get; set; } = null!;
    }
}
