using BusinessManager;
using Model.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ClasseController : Controller
    {
        // GET: Classe
        public ActionResult EleveClasse(int id = -1)
        {
            if(id == -1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Classe classe = Manager.Instance.getOneClasseById(id);
            if (classe == null)
                return HttpNotFound();
            return View(new ClasseVM(classe));
        }

        public ActionResult ClasseList()
        {
            List<ClasseVM> classeVMs = new List<ClasseVM>();
            foreach(Classe c in Manager.Instance.GetAllClasses())
            {
                classeVMs.Add(new ClasseVM(c));
            }
            return View(classeVMs);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ClasseVM model) 
        {
            if (ModelState.IsValid)
            {
                Classe classe = new Classe() { Eleves = new List<Eleve>(), Niveau = model.Niveau, NomEtablissement = model.NomEtablissement };
                Manager.Instance.AddClasse(classe);
                return RedirectToAction("ClasseList", "Classe");
            }
            return View();
        }
    }
}