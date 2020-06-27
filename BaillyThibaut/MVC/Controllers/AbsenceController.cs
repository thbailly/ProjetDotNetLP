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
    public class AbsenceController : Controller
    {
        // GET: Absence
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AbsenceVM model, int eleveId = -1)
        {
            if (eleveId == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                Absence absence = new Absence() { Motif = model.Motif, DateAbsence = model.DateAbsence, EleveId = eleveId };
                Manager.Instance.AddAbsence(absence);
                return RedirectToAction("Detail", "Eleve", new { id = absence.EleveId });
            }
            return View(model);
        }
    }
}