using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Command
{
    public class AbsenceCommand
    {
        private readonly MonContexte _context;

        public AbsenceCommand(MonContexte contexte)
        {
            _context = contexte;
        }

        public int Ajouter(Absence a)
        {
            _context.Absences.Add(a);
            return _context.SaveChanges();
        }
    }
}
