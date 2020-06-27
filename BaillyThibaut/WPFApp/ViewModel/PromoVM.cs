using BusinessManager;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.ViewModel.Base;

namespace WPFApp.ViewModel
{
    public class PromoVM : BaseVM
    {
        private ObservableCollection<EleveVM> _promo;
        private EleveVM _selected;

        public PromoVM()
        {
            Promo = new ObservableCollection<EleveVM>();
            foreach (Eleve e in Manager.Instance.GetAllEleve())
            {
                Promo.Add(new EleveVM(e));
            }
            if (Promo != null && Promo.Count > 0)
            {
                Promo = new ObservableCollection<EleveVM>(Promo.OrderBy(eleve => eleve.Nom).ThenBy(eleve => eleve.Prenom));
                Selected = Promo.First();
            }
        }

        public ObservableCollection<EleveVM> Promo
        {
            get { return _promo; }
            set {
                _promo = value;
                OnPropertyChanged("Promo");
            }
        }

        public EleveVM Selected { 
            get { return _selected; }
            set { 
                _selected = value; 
                OnPropertyChanged("Selected");
            } 
        }
    }
}
