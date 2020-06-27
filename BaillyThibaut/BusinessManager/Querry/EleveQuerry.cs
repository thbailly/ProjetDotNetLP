using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Querry
{
    public class EleveQuery
    {
        private readonly MonContexte _context;

        public EleveQuery(MonContexte context)
        {
            _context = context;
        }

        public IQueryable<Eleve> GetAll()
        {
            return _context.Eleves;
        }

        public List<Eleve> getByClassId(int id)
        {
            List<Eleve> res = new List<Eleve>();

            IQueryable<Eleve> eleves = _context.Eleves.Where(e => e.ClasseId == id);
            if(eleves != null)
                foreach (Eleve eleve in eleves)
                {
                    res.Add(eleve);
                }
            return res;
        }

        public Eleve GetOne(int id)
        {
            return _context.Eleves.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
