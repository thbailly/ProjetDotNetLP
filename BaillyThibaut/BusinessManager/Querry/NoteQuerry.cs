using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Querry
{
    public class NoteQuerry
    {
        private readonly MonContexte _context;

        public NoteQuerry(MonContexte context)
        {
            _context = context;
        }

        public IQueryable<Note> GetAll()
        {
            return _context.Notes;
        }

        public IQueryable<Note> GetAllByEleveId(int EleveId)
        {
            return _context.Notes.Where(n => n.EleveId == EleveId);
        }
    }
}
