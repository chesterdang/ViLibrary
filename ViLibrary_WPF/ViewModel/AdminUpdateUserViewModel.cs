﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using System.Windows;
using System.Windows.Input;
using Data;
using Service;
using System.Windows.Controls;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminUpdateUserViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;

        private User user;
        public User User { get { return user; } set { user = value; OnPropertyChanged(); } }

        public ICommand Update { get; set; }
        public AdminUpdateUserViewModel(User user)
        {
            _unitOfWork = new UnitOfWork(_context);
            this.user = user;
            Update = new RelayCommand<Window>(p => true, p =>
            {
                try
                {
                    var name = p.FindName("tbUName") as TextBox;
                    var adNo = p.FindName("tbUAdNo") as TextBox;
                    var email = p.FindName("tbUEmail") as TextBox;
                    var pass = p.FindName("tbUPass") as TextBox;

                    user.UserName = name.Text;
                    user.UserAdNo = adNo.Text;
                    user.UserEmail = email.Text;
                    user.UserPass = pass.Text;

                    _unitOfWork._userService.Update(user);
                    _unitOfWork.Save();
                    p.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot update book!");
                }
            });
        }

    }
}