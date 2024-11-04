namespace Notes.WebApi.Contracts.Notes
{
    public record UpdateNoteDTO
    (
        Guid Id,
        string Title,
        string Details
    );
}
