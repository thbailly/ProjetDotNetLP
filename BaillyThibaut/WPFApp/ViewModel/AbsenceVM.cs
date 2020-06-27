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
    public class AbsenceVM
    {
        public int Id { get; set; }
        public DateTime DateAbsence { get; set; }
        public int EleveId { get; set; }
        public String Motif { get; set; }

        private Window _window = null;
        private ICommand _addAbsenceOperation;
        private ICommand _closeWindowOperation;
        public AbsenceVM(Absence absence)
        {
            this.Id = absence.Id;
            this.DateAbsence = absence.DateAbsence;
            this.EleveId = absence.EleveId;
            this.Motif = absence.Motif;
        }

        public AbsenceVM(Absence absence, Window window)
        {
            this.Id = absence.Id;
            this.DateAbsence = absence.DateAbsence;
            this.EleveId = absence.EleveId;
            this.Motif = absence.Motif;
            _window = window;
        }


        public ICommand AddAbsenceOperation
        {
            get
            {
                if (_addAbsenceOperation == null)
                    _addAbsenceOperation = new RelayCommand(() => this.AddNote());
                return _addAbsenceOperation;
            }
        }

        public void AddNote()
        {
            Absence a = new Absence()
            {
                DateAbsence = this.DateAbsence,
                EleveId = this.EleveId,
                Motif = this.Motif
            };

            Manager.Instance.AddAbsence(a);
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
