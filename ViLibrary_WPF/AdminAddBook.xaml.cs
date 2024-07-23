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

namespace ViLibrary_WPF {
    /// <summary>
    /// Interaction logic for AdminAddBook.xaml
    /// </summary>
    public partial class AdminAddBook : Window
    {
        public AdminAddBook(LibraryDbContext db)
        {
            InitializeComponent();
            this.DataContext = new AdminAddBookViewModel(new AdminBooksViewModel(db),db);
        }
        //ADD THE BOOKS DETAILS INTO BOOK TABEL =>PL
       
    }
}
