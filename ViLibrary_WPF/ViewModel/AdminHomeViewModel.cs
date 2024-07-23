using BusinessObjects;
using Data;
using LibraryManagementSystem;
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
    public class AdminHomeViewModel : BaseViewModel
    {
        
        public ICommand Books { get; set; }
        public ICommand Users { get; set; }
        public ICommand Requests { get; set; }
        public ICommand Accepted { get; set; }
        public ICommand Return { get; set; }
        public ICommand Logout { get; set; }

        public AdminHomeViewModel(LibraryDbContext _context)
        {
            Books = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminBooks(_context));
            });
            Users = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminUsers(_context));
            });
            Requests = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminRequests(_context));
            });
            Accepted = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminAccepted(_context));
            });
            Return = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminReturn(_context));
            });
            Logout = new RelayCommand<Window>(p => true, p =>
            {
                p.Close();
                new MainWindow().Show();
            });
        }
    }
}
