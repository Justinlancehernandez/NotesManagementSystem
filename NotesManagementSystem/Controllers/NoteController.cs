using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagementSystem.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteService _noteService;
        public NoteController(IUnitOfWork unitOfWork, INoteService noteService)
        {
            _unitOfWork = unitOfWork;
            _noteService = noteService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddNote([FromBody] Note note)
        {
            _noteService.AddNote(note);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateNote([FromBody] Note note)
        {
            _noteService.UpdateNote(note);
            return Ok();
        }

        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult DeleteNote([FromRoute] int noteId)
        {
            _noteService.DeleteNote(noteId);
            return Ok();
        }

        [HttpGet]
        [Route("all/{userId}")]
        public IActionResult GetAllNotes ([FromRoute] int userId)
        {
            var allNotes=_noteService.GetAllNotes(userId);
            return Ok(allNotes);
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetNoteById([FromRoute] int userId)
        {
            var allNotes = _noteService.GetNoteById(userId);
            return Ok(allNotes);
        }



    }

}
