using Bwz.Rappi.Models;

namespace Bwz.Rappi.Data
{
    public class DbInitializer
    {
        private readonly CounterAppContext _context;

        public DbInitializer(CounterAppContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (_context.Database.EnsureCreated())
            {
                // add intial data
                _context.Counter.Add(new Counter { Current = 0 });
                // store everything to database
                _context.SaveChanges();
            }
        }
    }


}
