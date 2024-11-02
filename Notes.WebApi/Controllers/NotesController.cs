using Microsoft.AspNetCore.Mvc;
using Notes.Application.Interfaces;
using Notes.Contracts.Notes;
using Notes.Domain;
using Notes.WebApi.Contracts;

namespace Notes.WebApi.Controllers
{
    public class NotesController : BaseController
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDetailsVm>>> GetNotes()
        {
            var notes = await _notesService.GetAllNotes(userId);

            var response = notes.Select(b => new NoteDetailsVm(b.Id, b.Title, b.Details, 
                b.CreationDate, b.EditDate));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteDTO createNoteDTO)
        {
            var noteId = await _notesService.CreateNote(userId, Guid.NewGuid(),
                createNoteDTO.Title, createNoteDTO.Details);

            return Ok(noteId);
        }
    }
}
