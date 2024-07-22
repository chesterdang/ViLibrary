using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminAddBookViewModel : BaseViewModel
    {
        public ICommand Submit {  get; set; }
        public AdminAddBookViewModel()
        {
            Submit = new RelayCommand<Window>(p => true, p =>
            {

            }); 
        }
    }
}
