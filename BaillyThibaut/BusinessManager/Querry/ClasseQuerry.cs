using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Querry
{
    public class ClasseQuerry
    {
        private readonly MonContexte _context;

        public ClasseQuerry(MonContexte contexte)
        {
            _context = contexte;
        }

        public IQueryable<Classe> GetAll()
        {
            return _context.Classes;
        }

        public Classe GetOne(int id)
        {
            return _context.Classes.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
