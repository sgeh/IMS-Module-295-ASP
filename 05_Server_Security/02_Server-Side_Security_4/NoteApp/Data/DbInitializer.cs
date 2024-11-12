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
                string salt;
                string pwHash = HashGenerator.GenerateHash("user1234", out salt);
                User admin = new User { Email = "admin@example.com", Password = pwHash, Salt = salt };

                // add intial data
                _context.Users.Add(admin);
                _context.Notes.Add(
                    new Note
                    {
                        Name = "Einkaufen",
                        Description = "Brot, Energy Drink, Süsszeug, Salat",
                        DueDate = DateTime.Now,
                        User = admin
                    });
                // store everything to database
                _context.SaveChanges();
            }
        }
    }

}
