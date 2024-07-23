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
    public class AdminLoginViewModel : BaseViewModel
    {
        public ICommand Login { get; set; }

        public AdminLoginViewModel()
        {
            Login = new RelayCommand<Window>(p => true, p =>
            {
                var alert = p.FindName("alertAdmin") as Label;
                var username = p.FindName("tbAdminEmail") as TextBox;
                var password = p.FindName("tbAdminPass") as PasswordBox;
                if (username.Text!= string.Empty ||  password.Password!= string.Empty || username.Text != string.Empty && password.Password != string.Empty)
                {
                    try
                    {
                        if (username.Text.Equals("admin@admin.com") && password.Password.Equals("Admin123@"))
                        {
                            MessageBox.Show("Logged in successfully...");
                            new AdminHome().Show();
                            username.Clear();
                            password.Clear();
                            p.Close();
                        } else
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

                } else
                {
                    alert.Content = "Enter the fields properly...";
                }
            });
        }
    }
}
