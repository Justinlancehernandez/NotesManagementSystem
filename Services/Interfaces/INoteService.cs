 using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface INoteService
    {
        Note AddNote(Note note);
        Note UpdateNote(Note note);
        void DeleteNote(int noteId);
        IEnumerable<Note> GetAllNotes(int userId);

        Note GetNoteById(int noteId);

    }
}
