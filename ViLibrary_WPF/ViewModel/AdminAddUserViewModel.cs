using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using System.Windows;
using Data;
using Service;
using System.Windows.Controls;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminAddUserViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;
        private AdminUsersViewModel _adminUsersViewModel;

        public ICommand Submit { get; set; }

        public AdminAddUserViewModel(AdminUsersViewModel adminUsersViewModel)
        {
            _unitOfWork = new UnitOfWork(_context);
            _adminUsersViewModel = adminUsersViewModel;
            Submit = new RelayCommand<Window>(p => true, p =>
            {
                try
                {
                    var name = p.FindName("tbUName") as TextBox;
                    var adNo = p.FindName("tbUAdNo") as TextBox;
                    var email = p.FindName("tbUEmail") as TextBox;
                    var pass = p.FindName("tbUPass") as TextBox;

                    var user = new User()
                    {
                        UserName = name.Text,
                        UserAdNo = adNo.Text,
                        UserEmail = email.Text,
                        UserPass = pass.Text
                    };
                    _unitOfWork._userService.Add(user);
                    _unitOfWork.Save();
                    _adminUsersViewModel.AddUser(user);
                    p.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot create new user!");
                }
            });
            
        }

    }
}
