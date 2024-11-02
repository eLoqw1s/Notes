using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.Notes.Repositories;

namespace Notes.Application.Common.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<List<Note>> GetAllNotes(Guid UserId)
        {
            return await _notesRepository.Get(UserId);
        }

        public async Task<Guid> CreateNote(Guid UserId, Guid Id, string Title, string Details)
        {
            return await _notesRepository.Create(UserId, Id, Title, Details);
        }

        public async Task<Guid> UpdateNote(Guid UserId, Guid Id, string Title, string Details)
        {
            return await _notesRepository.Update(UserId, Id, Title, Details);
        }

        public async Task<Guid> DeleteNote(Guid UserId, Guid Id)
        {
            return await _notesRepository.Delete(UserId, Id);
        }
    }
}
