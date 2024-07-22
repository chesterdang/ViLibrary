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

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for UserTransaction.xaml
    /// </summary>
    public partial class UserTransaction : UserControl
    {
        public int userId;
        //INITIALIZE THE REQUEST GV AND RETURN GV =>PL
        public UserTransaction()
        {
            InitializeComponent();
        }
        
    }
}
