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
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Data;
using ViLibrary_WPF.ViewModel;



namespace ViLibrary_WPF
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin(LibraryDbContext db)
        {
            InitializeComponent();
            this.DataContext = new AdminLoginViewModel(db);
        }
        
    }
}
