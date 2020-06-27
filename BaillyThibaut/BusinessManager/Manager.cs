using BusinessManager.Command;
using BusinessManager.Querry;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager
{
    public class Manager
    {
        private readonly MonContexte contexte;
        private static Manager _manager = null;

        private Manager()
        {
            contexte = new MonContexte();
        }

        public static Manager Instance
        {
            get
            {
                if (_manager == null)
                    _manager = new Manager(); ;
                return _manager;
            }
        }

        public List<Eleve> GetAllEleve()
        {
            EleveQuery eq = new EleveQuery(contexte);
            List<Eleve> eleves = new List<Eleve>();
            NoteQuerry nq = new NoteQuerry(contexte);
            AbsenceQuerry aq = new AbsenceQuerry(contexte);
            foreach (Eleve e in eq.GetAll().ToList())
            {
                List<Note> notes = new List<Note>();
                notes = nq.GetAllByEleveId(e.Id).ToList();
                e.Notes = notes != null ? notes : new List<Note>();
                e.GetMoyenne();
                List<Absence> absences = new List<Absence>();
                absences = aq.GetAllByEleveId(e.Id).ToList();
                e.Absences = absences != null ? absences : new List<Absence>();
                eleves.Add(e);
            }
            return eleves;
        }
        public int AjouterEleve(Eleve e)
        {
            EleveCommand ec = new EleveCommand(contexte);
            return ec.Ajouter(e);
        }

        public List<Eleve> getEleveByClasseId(int id)
        {
            EleveQuery eq = new EleveQuery(contexte);
            NoteQuerry nq = new NoteQuerry(contexte);
            AbsenceQuerry aq = new AbsenceQuerry(contexte);
            List<Eleve> eleves = eq.getByClassId(id);
            foreach(Eleve e in eleves)
            {
                e.Notes = nq.GetAllByEleveId(e.Id).ToList() != null ? nq.GetAllByEleveId(e.Id).ToList() : new List<Note>();
                e.Absences = aq.GetAllByEleveId(e.Id).ToList() != null ? aq.GetAllByEleveId(e.Id).ToList() : new List<Absence>();
            }
            return eleves;
        }

        public Eleve getOneEleveById(int id)
        {
            EleveQuery eq = new EleveQuery(contexte);
            NoteQuerry nq = new NoteQuerry(contexte);
            AbsenceQuerry aq = new AbsenceQuerry(contexte);
            Eleve e = eq.GetOne(id);
            e.Notes = nq.GetAllByEleveId(e.Id).ToList() != null ? nq.GetAllByEleveId(e.Id).ToList() : new List<Note>();
            e.GetMoyenne();
            e.Absences  = aq.GetAllByEleveId(e.Id).ToList() != null ? aq.GetAllByEleveId(e.Id).ToList() : new List<Absence>();
            return e;
        }

        public Classe getOneClasseById(int id)
        {
            ClasseQuerry cq = new ClasseQuerry(contexte);
            EleveQuery eq = new EleveQuery(contexte);
            Classe classe = cq.GetOne(id);
            foreach (Eleve e in eq.getByClassId(id))
            {
                Eleve eleve = getOneEleveById(e.Id);
                if(!classe.Eleves.Contains(eleve))
                    classe.Eleves.Add(eleve);
            }

            return classe;
        }

        public List<Classe> GetAllClasses()
        {
            ClasseQuerry cq = new ClasseQuerry(contexte);
            List<Classe> classes = new List<Classe>();
            
            foreach(Classe c in cq.GetAll().ToList())
            {
                c.Eleves = getEleveByClasseId(c.Id);
                foreach(Eleve e in c.Eleves)
                {

                }
                classes.Add(c);
            }
            return classes;
        }

        public int AddAbsence(Absence absence)
        {
            AbsenceCommand ac = new AbsenceCommand(contexte);
            return ac.Ajouter(absence);
        }

        public int AddNote(Note note)
        {
            NoteCommand nc = new NoteCommand(contexte);
            return nc.Ajouter(note);
        }

        public int AddClasse(Classe classe)
        {
            ClasseCommand cc = new ClasseCommand(contexte);
            return cc.Ajouter(classe);
        }

        public List<Absence> getAllAbsence()
        {
            AbsenceQuerry ac = new AbsenceQuerry(contexte);
            return ac.GetAll().ToList();
        }

        public int ModifyEleve(Eleve e)
        {
            EleveCommand ec = new EleveCommand(contexte);
            return ec.Modifier(e);
        }

        public List<Note> getNotesByEleveId(int id)
        {
            NoteQuerry nq = new NoteQuerry(contexte);
            List<Note> notes = new List<Note>();
            foreach (Note n in nq.GetAllByEleveId(id))
            {
                notes.Add(n);
            }
            return notes;
        }

        public int DeleteClasseById(int id)
        {
            ClasseCommand cc = new ClasseCommand(contexte);
            ClasseQuerry cq = new ClasseQuerry(contexte);
            Classe c = cq.GetOne(id);
            return cc.Supprimer(c);
        }

        public int ModifyClasse(Classe classe)
        {
            ClasseCommand cc = new ClasseCommand(contexte);
            return cc.Modify(classe);
        }
    }
}
