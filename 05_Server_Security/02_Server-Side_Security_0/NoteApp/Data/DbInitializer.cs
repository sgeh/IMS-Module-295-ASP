using NoteApp.Models;

namespace NoteApp.Data
{
    public class DbInitializer
    {
        private readonly NoteAppContext _context;

        public DbInitializer(NoteAppContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (_context.Database.EnsureCreated())
            {
                // add intial data
                _context.Notes.Add(
                    new Note
                    {
                        Name = "Einkaufen",
                        Description = "Brot, Energy Drink, Süsszeug, Salat",
                        DueDate = DateTime.Now
                    });
                // store everything to database
                _context.SaveChanges();
            }
        }
    }
}
