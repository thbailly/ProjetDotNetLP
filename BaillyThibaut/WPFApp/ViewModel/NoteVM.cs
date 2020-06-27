using BusinessManager;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp.ViewModel.Base;

namespace WPFApp.ViewModel
{
    public class NoteVM
    {
        public int Id { get; set; }
        public String Matiere { get; set; }
        public DateTime DateNote { get; set; }
        public String Appreciation { get; set; }
        public int Valeur { get; set; }
        public int EleveId { get; set; }

        private ICommand _addNoteOperation;
        private ICommand _closeWindowOperation;
        private Window _window = null;

        public NoteVM(Note note)
        {
            this.Id = note.Id;
            this.Matiere = note.Matiere;
            this.DateNote = note.DateNote;
            this.Appreciation = note.Appreciation;
            this.Valeur = note.Valeur;
            this.EleveId = note.EleveId;
        }

        public NoteVM(Note note, Window window)
        {
            this.Id = note.Id;
            this.Matiere = note.Matiere;
            this.DateNote = note.DateNote;
            this.Appreciation = note.Appreciation;
            this.Valeur = note.Valeur;
            this.EleveId = note.EleveId;
            this._window = window;
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
            Note n = new Note()
            {
                EleveId = this.EleveId,
                Appreciation = this.Appreciation,
                DateNote = this.DateNote,
                Matiere = this.Matiere,
                Valeur = this.Valeur
            };

            Manager.Instance.AddNote(n);
            this.CloseWindow();
        }

        public ICommand CloseWindowOperation
        {
            get
            {
                if (_closeWindowOperation == null)
                    _closeWindowOperation = new RelayCommand(() => this.CloseWindow());
                return _closeWindowOperation;
            }
        }

        public void CloseWindow()
        {
            _window.Close();
        }
    }    
}
