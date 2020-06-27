using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class AbsenceVM
    {
        public int Id { get; set; }
        public DateTime DateAbsence { get; set; }
        public int EleveId { get; set; }
        public String Motif { get; set; }

        public AbsenceVM()
        {

        }
        public AbsenceVM(Absence absence)
        {
            this.Id = absence.Id;
            this.DateAbsence = absence.DateAbsence;
            this.EleveId = absence.EleveId;
            this.Motif = absence.Motif;
        }
    }
}