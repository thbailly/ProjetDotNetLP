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
    public class EleveController : Controller
    {
        // GET: Eleve
        public ActionResult EleveList(string recherche)
        {
            List<Eleve> eleves = Manager.Instance.GetAllEleve();
            List<EleveVM> eleveVMs = new List<EleveVM>();
            if (eleves != null)
            {
                foreach (Eleve e in eleves)
                {
                    eleveVMs.Add(new EleveVM(e));
                }
            }
            if (recherche != null)
            {
                eleveVMs = eleveVMs.Where(eleve => eleve.Nom.ToLower().Contains(recherche.ToLower()) || eleve.Prenom.ToLower().Contains(recherche.ToLower())).ToList();
            }
            
            return View(eleveVMs);
        }

        public ActionResult Detail(int id = -1)
        {
            if (id == -1)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Eleve eleve = Manager.Instance.getOneEleveById(id);

            if (eleve == null)
                return HttpNotFound();

            return View(new EleveVM(eleve));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EleveVM model)
        {
            if (ModelState.IsValid)
            {
                Eleve eleve = new Eleve() { Absences = model.Absences, ClasseId = model.ClasseId, DateDeNaissance = model.DateDeNaissance, Nom = model.Nom, Notes = model.Notes, Prenom = model.Prenom };
                Manager.Instance.AjouterEleve(eleve);
                return RedirectToAction("EleveList", "Eleve");
            }
            return View();
        }
    }
}