using Notes.Domain;

namespace Notes.Application.Interfaces
{
    public interface INotesService
    {
        Task<Guid> CreateNote(Guid UserId, Guid Id, string Title, string Details);
        Task<Guid> DeleteNote(Guid UserId, Guid Id);
        Task<List<Note>> GetAllNotes(Guid UserId);
        Task<Guid> UpdateNote(Guid UserId, Guid Id, string Title, string Details);
    }
}