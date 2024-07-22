using BusinessObjects;
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

        public AdminHomeViewModel()
        {
            Books = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminBooks());
            });
            Users = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminUsers());
            });
            Requests = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminRequests());
            });
            Accepted = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminAccepted());
            });
            Return = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("adminStackPanel") as StackPanel;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(new AdminReturn());
            });
            Logout = new RelayCommand<Window>(p => true, p =>
            {
                p.Close();
                new MainWindow().Show();
            });
        }
    }
}
