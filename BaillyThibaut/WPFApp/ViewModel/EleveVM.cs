using BusinessManager;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp.ViewModel.Base;

namespace WPFApp.ViewModel
{
    public class EleveVM : BaseVM
    {

        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public ObservableCollection<NoteVM> _notes;
        public ObservableCollection<AbsenceVM> _absences;
        public double Moyenne { get; set; }
        public int ClasseId { get; set; }

        private RelayCommand _updateOperation;
        private RelayCommand _addNoteOperation;
        private RelayCommand _addAbsenceOperation;

        public EleveVM(Eleve eleve)
        {
            this.Id = eleve.Id;
            this.Nom = eleve.Nom;
            this.Prenom = eleve.Prenom;
            this.DateDeNaissance = eleve.DateDeNaissance;
            this.ClasseId = eleve.ClasseId;
            this.Moyenne = eleve.Moyenne;
            this.Notes = new ObservableCollection<NoteVM>();
            this.Absences = new ObservableCollection<AbsenceVM>();
            if (eleve.Notes != null)
            {
                foreach (Note n in eleve.Notes)
                {
                    this.Notes.Add(new NoteVM(n));
                }

            }
            if(eleve.Absences != null)
            {
                foreach(Absence a in eleve.Absences)
                {
                    this.Absences.Add(new AbsenceVM(a));
                }
            }
        }

        public ObservableCollection<NoteVM> Notes {
            get {
                return _notes;
            }
            set {
                _notes = value;
                OnPropertyChanged("Notes");
            }   
        }
        public ObservableCollection<AbsenceVM> Absences
        {
            get
            {
                return _absences;
            }
            set
            {
                _absences = value;
                OnPropertyChanged("Absence");
            }
        }

        public ICommand UpdateOperation
        {
            get
                {
                if (_updateOperation == null)
                    _updateOperation = new RelayCommand(() => this.Save());
                return _updateOperation;
            }
        }

        private void Save()
        {
            List<Note> notesTmp = new List<Note>();
            List<Absence> absencesTmp = new List<Absence>();

            foreach(NoteVM noteVM in Notes)
            {
                Note n = new Note() { Appreciation = noteVM.Appreciation, DateNote = noteVM.DateNote, EleveId = noteVM.EleveId, Matiere = noteVM.Matiere, Valeur = noteVM.Valeur };
                notesTmp.Add(n);
            }

            foreach(AbsenceVM absenceVM in Absences)
            {
                Absence a = new Absence() { DateAbsence = absenceVM.DateAbsence, EleveId = absenceVM.EleveId, Motif = absenceVM.Motif };
                absencesTmp.Add(a);
            }

            Eleve e = new Eleve() { Absences = absencesTmp, Notes = notesTmp, ClasseId = this.ClasseId, DateDeNaissance = this.DateDeNaissance, Moyenne = this.Moyenne, Nom = this.Nom, Prenom = this.Prenom, Id = this.Id };

            Manager.Instance.ModifyEleve(e);
        } 


        public ICommand AddNoteOperation
        {
            get
            {
                if (_addNoteOperation == null)
                    _addNoteOperation = new RelayCommand(() => this.AddNote());
                return _addNoteOperation;
            }
        }

        public void AddNote()
        {
            Views.AddNote addNoteWindow = new Views.AddNote(this.Id);
            addNoteWindow.ShowDialog();
        }

        public ICommand AddAbsenceOperation
        {
            get
            {
                if (_addAbsenceOperation == null)
                    _addAbsenceOperation = new RelayCommand(() => this.AddAbsence());
                return _addAbsenceOperation;
            }
        }

        public void AddAbsence()
        {
            Views.AddAbsence addAbsenceWindow = new Views.AddAbsence(this.Id);
            addAbsenceWindow.ShowDialog();
        }
    }
}
