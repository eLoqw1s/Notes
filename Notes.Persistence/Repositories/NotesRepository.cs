using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Application.Common.Exeptions;

namespace Notes.Persistence.Notes.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext _context;

        public NotesRepository(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> Get(Guid UserId)
        {
            var notes = await _context.Notes
                .Where(b => b.UserId == UserId)
                .AsNoTracking()
                .ToListAsync();
            return notes;
        }

        public async Task<Guid> Create(Guid UserId, Guid Id, string Title, string Details)
        {
            var noteEntity = new Note
            {
                UserId = UserId,
                Title = Title,
                Details = Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _context.AddAsync(noteEntity);
            await _context.SaveChangesAsync();

            return noteEntity.Id;
        }

        public async Task<Guid> Update(Guid UserId, Guid Id, string Title, string Details)
        {
            var noteEntity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == Id);

            if (noteEntity == null || noteEntity.UserId != UserId)
            {
                throw new NotFoundExeption(nameof(Note), Id);
            }

            noteEntity.Details = Details;
            noteEntity.Title = Title;
            noteEntity.EditDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return noteEntity.Id;
        }

        public async Task<Guid> Delete(Guid UserId, Guid Id)
        {
            await _context.Notes
                .Where(b => b.UserId == UserId)
                .Where(b => b.Id == Id)
                .ExecuteDeleteAsync();

            return Id;
        }
    }
}
