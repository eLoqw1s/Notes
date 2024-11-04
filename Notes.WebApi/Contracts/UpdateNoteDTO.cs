namespace Notes.WebApi.Contracts
{
    public record UpdateNoteDTO
    (
        Guid Id,
        string Title,
        string Details
    );
}
