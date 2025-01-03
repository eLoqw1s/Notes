﻿namespace Notes.WebApi.Contracts.Notes
{
    public record NoteDetailsVm
    (
        Guid Id,
        string Title,
        string Details,
        DateTime CreationDate,
        DateTime? EditDate
    );
}
