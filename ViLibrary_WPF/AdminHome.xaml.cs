﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViLibrary_WPF.ViewModel;

namespace ViLibrary_WPF
{
    /// <summary>
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    { 

        public AdminHome(LibraryDbContext db)
        {
            InitializeComponent();
            this.DataContext = new AdminHomeViewModel(db);
         }
        
    }
}
