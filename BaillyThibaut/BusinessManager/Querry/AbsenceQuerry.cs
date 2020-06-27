using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Querry
{
    public class AbsenceQuerry
    {
        private readonly MonContexte _context;

        public AbsenceQuerry(MonContexte context)
        {
            _context = context;
        }

        public IQueryable<Absence> GetAll()
        {
            return _context.Absences;
        }

        public IQueryable<Absence> GetAllByEleveId(int EleveId)
        {
            return _context.Absences.Where(a => a.EleveId == EleveId);
        }
    }
}
