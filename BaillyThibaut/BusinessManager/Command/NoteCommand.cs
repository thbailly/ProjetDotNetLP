using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Command
{
    public class NoteCommand
    {
        private readonly MonContexte _context;

        public NoteCommand(MonContexte contexte)
        {
            _context = contexte;
        }

        public int Ajouter(Note note)
        {
            _context.Notes.Add(note);
            return _context.SaveChanges();
        }
    }
}
