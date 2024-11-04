using Notes.Domain.Models;

namespace Notes.Application.Interfaces
{
    public interface INotesRepository
    {
        Task<Guid> Create(Guid UserId, Guid Id, string Title, string Details);
        Task<Guid> Delete(Guid UserId, Guid Id);
        Task<List<Note>> Get(Guid UserId);
        Task<Note> GetById(Guid UserId, Guid Id);
        Task<Guid> Update(Guid UserId, Guid Id, string Title, string Details);
    }
}