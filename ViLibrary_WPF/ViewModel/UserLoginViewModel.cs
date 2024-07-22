using BusinessObjects;
using Data;
using LibraryManagementSystem;
using Service;
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
    public class UserLoginViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork unitOfWork;
        public ICommand Login {  get; set; }
        public UserLoginViewModel()
        {
            unitOfWork = new UnitOfWork(_context);
            Login = new RelayCommand<Window>(p => true, p =>
            {
                var username = p.FindName("tbUserEmail") as TextBox;
                var password = p.FindName("tbUserPass") as PasswordBox;
                var alert = p.FindName("alertUser") as Label;
                if (username.Text != string.Empty || password.Password != string.Empty || username.Text != string.Empty && password.Password != string.Empty)
                {
                    try
                    {
                        var user = unitOfWork._userService.Get(u => (u.UserEmail == username.Text && u.UserPass == password.Password));
                        if (user!= null)
                        {
                            MessageBox.Show("Logged in successfully...");
                            new UserHome(user).Show();
                            username.Clear();
                            password.Clear();
                            p.Hide();
                        }
                        else
                        {
                            alert.Content = "Invalid email id or password...";
                            username.Clear();
                            password.Clear();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                    }

                }
                else
                {
                    alert.Content = "Enter the fields properly...";
                }
            });
        }
    }
}
