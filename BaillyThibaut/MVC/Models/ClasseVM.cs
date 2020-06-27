using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ClasseVM
    {
        public int Id { get; set; }
        public String NomEtablissement { get; set; }
        public String Niveau { get; set; }
        public ICollection<Eleve> Eleves { get; set; }

        public ClasseVM()
        {
            this.Eleves = new List<Eleve>();
        }

        public ClasseVM(Classe classe)
        {
            this.Id = classe.Id;
            this.NomEtablissement = classe.NomEtablissement;
            this.Niveau = classe.Niveau;
            this.Eleves = classe.Eleves;
        }
    }
}