using BusinessManager;
using Model.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private const int NB_ELEVE = 5;
        public ActionResult Index()
        {
            List<Eleve> eleves = Manager.Instance.GetAllEleve();
            List<Absence> absences = Manager.Instance.getAllAbsence();
            List<Eleve> bests = new List<Eleve>();
            List<Absence> lastAbsences = new List<Absence>();
            HomeVM homeVM = new HomeVM();
            foreach(Eleve e in eleves)
            {
                e.GetMoyenne();
            }
            bests = eleves.OrderByDescending(eleve => eleve.Moyenne).Take(NB_ELEVE).ToList();
            lastAbsences = absences.OrderByDescending(absence => absence.DateAbsence).Take(NB_ELEVE).ToList();
            homeVM.Absences = lastAbsences;
            homeVM.BestEleves = bests;
            return View(homeVM);
        }
    }
}