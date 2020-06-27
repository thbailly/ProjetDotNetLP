using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Command
{
    public class EleveCommand
    {
        private readonly MonContexte _context;

        public EleveCommand(MonContexte Context)
        {
            _context = Context;
        }
        public int Ajouter(Eleve e)
        {
            _context.Eleves.Add(e);
            return _context.SaveChanges();
        }

        public int Modifier(Eleve e)
        {
            Eleve updateEleve = _context.Eleves.Where(eleve => eleve.Id == e.Id).FirstOrDefault();
            if(updateEleve != null)
            {
                updateEleve.Nom = e.Nom;
                updateEleve.Prenom = e.Prenom;
                updateEleve.DateDeNaissance = e.DateDeNaissance;
            }
            return _context.SaveChanges();
        }
    }
}
