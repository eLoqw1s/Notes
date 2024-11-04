using Microsoft.EntityFrameworkCore;
using Notes.Domain.Models;

namespace Notes.Persistence
{
    public class NotesDbContext: DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options) 
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
