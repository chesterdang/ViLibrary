using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Data;

namespace ViLibrary_WPF.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand UserLog {  get; set; }
        public ICommand AdminLog { get; set;}

        public MainWindowViewModel(LibraryDbContext _context)
        {
            UserLog = new RelayCommand<Window>(p => true, p =>
            {
                new UserLogin(_context).Show();
                p.Hide();
            });
            AdminLog = new RelayCommand<Window>(p => true, p =>
            {
                new AdminLogin(_context).Show();
                p.Hide();
            });
        }
    }
}
