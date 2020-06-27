using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EleveVM
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Absence> Absences { get; set; }
        public double Moyenne { get; set; }
        public int ClasseId { get; set; }

        public EleveVM()
        {

        }
        public EleveVM(Eleve eleve)
        {
            this.Id = eleve.Id;
            this.Nom = eleve.Nom;
            this.Prenom = eleve.Prenom;
            this.DateDeNaissance = eleve.DateDeNaissance;
            this.Notes = eleve.Notes;
            this.Absences = eleve.Absences;
            this.ClasseId = eleve.ClasseId;
            this.Moyenne = eleve.Moyenne;
            
        }
    }
}