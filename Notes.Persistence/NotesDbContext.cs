using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Persistence
{
    public class NotesDbContext: DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options) 
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
