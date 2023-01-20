using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteRepository _noteRepository;
        public NoteService(IUnitOfWork unitOfWork, INoteRepository noteRepository)
        {
            _unitOfWork = unitOfWork;
            _noteRepository = noteRepository;
        }
        public Note AddNote(Note note)
        {

            var newNote = new Note()
            {
                header = note.header,
                description = note.description,
                userId = note.userId,
            };
            _unitOfWork.Notes.Add(newNote);
            _unitOfWork.Complete();
            return newNote;
        }
        public Note UpdateNote(Note note)
        {

            var getNote = _unitOfWork.Notes.GetById(note.noteId);
            getNote.header = note.header;
            getNote.description = note.description;



            _unitOfWork.Complete();
            return getNote;
        }
        public void DeleteNote(int noteId)
        {
            var getNote = _unitOfWork.Notes.GetById(noteId);
            _unitOfWork.Notes.Remove(getNote);
            _unitOfWork.Complete();

        }
        public IEnumerable <Note> GetAllNotes(int userId)
        {
            return _unitOfWork.Notes.GetAll().Where(note => note.userId == userId);
        }
        public Note GetNoteById(int noteId)
        {
            var getNote = _unitOfWork.Notes.GetById(noteId);
            return getNote;

        }
    }
}
