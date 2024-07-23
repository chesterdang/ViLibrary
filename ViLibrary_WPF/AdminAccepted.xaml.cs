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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Collections.ObjectModel;
using Data;
using ViLibrary_WPF.ViewModel;

namespace ViLibrary_WPF
{
    /// <summary>
    /// Interaction logic for AdminAccepted.xaml
    /// </summary>
    public partial class AdminAccepted : UserControl
    {
        //INITIALIZE THE ACCEPTED GV =>PL
        public AdminAccepted(LibraryDbContext db)
        {
            InitializeComponent();
            this.DataContext = new AdminAcceptedViewModel(db);
        }
        
    }
}
