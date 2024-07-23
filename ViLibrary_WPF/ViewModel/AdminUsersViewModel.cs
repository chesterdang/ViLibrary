using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;
using LibraryManagementSystem;
using System.Windows.Controls;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.ObjectModel;
using Service;
using Data;
using Microsoft.Identity.Client.NativeInterop;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminUsersViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;


        private ObservableCollection<User> users;
        public ObservableCollection<User> Users { get { return users; } set { users = value;} }

        public ICommand Add { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }

        public AdminUsersViewModel()
        {
            _unitOfWork = new UnitOfWork(_context);
            users = new ObservableCollection<User>(_unitOfWork._userService.GetAll());
            Add = new RelayCommand<UserControl>(p => true, p =>
            {
                var addUserWindow = new AdminAddUser();
                var addUserVM = new AdminAddUserViewModel(this);
                addUserWindow.DataContext = addUserVM;
                addUserWindow.Show();
            });
            Edit = new RelayCommand<User>(p => true, p =>
            {
                var updateWindow = new AdminUpdateUser();
                updateWindow.DataContext = new AdminUpdateUserViewModel(p);
                updateWindow.Show();
            });
            Delete = new RelayCommand<User>(p => true, p =>
            {
                MessageBoxResult rs = MessageBox.Show($"Do you want to delete the user with name {p.UserName}",
                    "User Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (rs == MessageBoxResult.Yes)
                {
                    _unitOfWork._userService.Delete(p);
                    _unitOfWork.Save();
                    Users.Remove(p);
                }
            });
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
