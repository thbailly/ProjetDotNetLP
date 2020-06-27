using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class NoteVM
    {
        public int Id { get; set; }
        public String Matiere { get; set; }
        public DateTime DateNote { get; set; }
        public String Appreciation { get; set; }
        public int Valeur { get; set; }
        public int EleveId { get; set; }

        public NoteVM()
        {

        }

        public NoteVM(Note note)
        {
            this.Id = note.Id;
            this.Matiere = note.Matiere;
            this.DateNote = note.DateNote;
            this.Appreciation = note.Appreciation;
            this.Valeur = note.Valeur;
            this.EleveId = note.EleveId;
        }
    }
}