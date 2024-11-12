using Microsoft.EntityFrameworkCore;

namespace NoteApp.Models
{
    public class NoteAppContext : DbContext
    {
        public NoteAppContext(DbContextOptions<NoteAppContext> options)
            : base(options) { }

        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
