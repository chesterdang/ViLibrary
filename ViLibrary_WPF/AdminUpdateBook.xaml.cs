using BusinessObjects;
using Data;
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
using ViLibrary_WPF.ViewModel;

namespace ViLibrary_WPF
{
    /// <summary>
    /// Interaction logic for AdminUpdateBook.xaml
    /// </summary>
    public partial class AdminUpdateBook : Window
    {
        public int bookId;
        //INITIALIZE THE BOOKS UPDATE =>PL
        public AdminUpdateBook()
        {
            InitializeComponent();
        }
       
    }
}
