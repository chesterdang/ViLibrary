using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdminAddUser.xaml
    /// </summary>
    public partial class AdminAddUser : Window
    {
        public AdminAddUser(LibraryDbContext db)
        {
            InitializeComponent();
        }
        
    }
}
