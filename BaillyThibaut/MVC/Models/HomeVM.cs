using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class HomeVM
    {
        public ICollection<Eleve> BestEleves { get; set; }
        public ICollection<Absence> Absences { get; set; }

        public HomeVM()
        {
            BestEleves = new List<Eleve>();
            Absences = new List<Absence>();
        }

    }
}