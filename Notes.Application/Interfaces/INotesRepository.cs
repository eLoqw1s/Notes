using Notes.Domain;

namespace Notes.Persistence.Notes.Repositories
{
    public interface INotesRepository
    {
        Task<Guid> Create(Guid UserId, Guid Id, string Title, string Details);
        Task<Guid> Delete(Guid UserId, Guid Id);
        Task<List<Note>> Get(Guid UserId);
        Task<Guid> Update(Guid UserId, Guid Id, string Title, string Details);
    }
}