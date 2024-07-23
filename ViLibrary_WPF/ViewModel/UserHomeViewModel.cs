using BusinessObjects;
using Data;
using LibraryManagementSystem;
using Microsoft.Identity.Client.NativeInterop;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViLibrary_WPF.ViewModel
{
    public class UserHomeViewModel : BaseViewModel
    {
        public ICommand Borrow {  get; set; }
        public ICommand Transactions { get; set; }
        public ICommand Logout { get; set; }
        public UserHomeViewModel(User user)
        {

            Borrow = new RelayCommand<Window>(p => true, p =>
            {
                var stackPanel = p.FindName("userStackPanel") as StackPanel;
                var userBorrow = new UserBorrow(user);
                stackPanel.Children.Clear();
                stackPanel.Children.Add(userBorrow);
            });
            Transactions = new RelayCommand<Window>(p=>true, p =>
            {
                var stackPanel = p.FindName("userStackPanel") as StackPanel;
                var userTransaction = new UserTransaction(user);
                stackPanel.Children.Clear();
                stackPanel.Children.Add(userTransaction);
            });
            Logout = new RelayCommand<Window>(p => true, p =>
            {
                p.Close();
                new MainWindow().Show();
            });
        }
    }
}
