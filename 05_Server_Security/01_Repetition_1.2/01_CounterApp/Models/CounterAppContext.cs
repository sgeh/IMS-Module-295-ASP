using Microsoft.EntityFrameworkCore;

namespace Bwz.Rappi.Models
{
    public class CounterAppContext : DbContext
    {
        public CounterAppContext(DbContextOptions<CounterAppContext> options)
            : base(options) { }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Counter> Counter { get; set; }
    }
}
