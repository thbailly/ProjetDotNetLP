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
    public class NoteController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(NoteVM model, int eleveId = -1)
        {
            if(eleveId == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                Note note = new Note() { Appreciation = model.Appreciation, DateNote = model.DateNote, EleveId = eleveId, Matiere = model.Matiere, Valeur = model.Valeur };
                Manager.Instance.AddNote(note);
                return RedirectToAction("Detail", "Eleve", new { id = note.EleveId });
            }
            return View(model);
        }
    }
}