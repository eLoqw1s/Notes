using Microsoft.AspNetCore.Mvc;
using Notes.Application.Interfaces;
using Notes.WebApi.Contracts.Notes;

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
        public async Task<ActionResult<List<NoteDetailsVm>>> GetAllNotes()
        {
            var notes = await _notesService.GetAll(userId);

            var response = notes.Select(b => new NoteDetailsVm(b.Id, b.Title, b.Details, 
                b.CreationDate, b.EditDate));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<NoteDetailsVm>> GetOneNote(Guid id)
        {
            var note = await _notesService.GetOne(userId, id);

            var response = new NoteDetailsVm 
            (
                note.Id, 
                note.Title, 
                note.Details,
                note.CreationDate,
                note.EditDate
            );

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteDTO createNoteDTO)
        {
            var noteId = await _notesService.CreateNote(userId, Guid.NewGuid(),
                createNoteDTO.Title, createNoteDTO.Details);

            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateNote([FromBody] UpdateNoteDTO updateNoteDTO)
        {
            var noteId = await _notesService.UpdateNote(userId, updateNoteDTO.Id,
                updateNoteDTO.Title, updateNoteDTO.Details);

            return Ok(noteId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteNote(Guid id)
        {
            var noteId = await _notesService.DeleteNote(userId, id);
            return Ok(noteId);
        }
    }
}
