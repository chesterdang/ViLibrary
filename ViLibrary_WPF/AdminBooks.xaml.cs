using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Sql;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using Data;
using ViLibrary_WPF.ViewModel;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminBooks.xaml
    /// </summary>
    public partial class AdminBooks : UserControl
    {
        //INITIALIZE THE BOOKS GV =>PL
        public AdminBooks(LibraryDbContext db)
        {
            InitializeComponent();
            this.DataContext = new AdminBooksViewModel(db);
        }
        
    }
}
