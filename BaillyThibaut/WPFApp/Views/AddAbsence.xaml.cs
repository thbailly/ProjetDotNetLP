using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFApp.ViewModel;

namespace WPFApp.Views
{
    /// <summary>
    /// Logique d'interaction pour AddAbsence.xaml
    /// </summary>
    public partial class AddAbsence : Window
    {
        public AddAbsence()
        {
            InitializeComponent();
        }

        public AddAbsence(int idEleve)
        {
            InitializeComponent();
            DataContext = new AbsenceVM(new Absence() { EleveId = idEleve, DateAbsence = DateTime.Now }, this);

        }
    }
}
