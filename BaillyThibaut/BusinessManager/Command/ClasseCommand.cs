using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Command
{
    public class ClasseCommand
    {
        private readonly MonContexte _context;

        public ClasseCommand(MonContexte contexte)
        {
            _context = contexte;
        }

        public int Ajouter(Classe classe)
        {
            _context.Classes.Add(classe);
            return _context.SaveChanges();
        }

        public int Supprimer(Classe classe)
        {
            _context.Classes.Remove(classe);
            return _context.SaveChanges();
        }

        public int Modify(Classe classe)
        {
            Classe updateClasse = _context.Classes.Where(c => c.Id == classe.Id).FirstOrDefault();
            if(updateClasse != null)
            {
                updateClasse.Niveau = classe.Niveau;
                updateClasse.NomEtablissement = classe.NomEtablissement;
                updateClasse.Eleves = classe.Eleves;
            }
            return _context.SaveChanges();
        }
    }
}
