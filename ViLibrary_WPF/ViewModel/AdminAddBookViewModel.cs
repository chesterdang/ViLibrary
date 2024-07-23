using BusinessObjects;
using ViLibrary_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Service;
using System.Collections.ObjectModel;
using Data;
using LibraryManagementSystem;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminAddBookViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;
        private AdminBooksViewModel _adminBooksViewModel;
        public ICommand Submit {  get; set; }
        
        public AdminAddBookViewModel(AdminBooksViewModel adminBooksViewModel)
        {
            _adminBooksViewModel = adminBooksViewModel;
            _unitOfWork = new UnitOfWork(_context);
            Submit = new RelayCommand<Window>(p => true, p =>
            {
                try
                {
                    var name = p.FindName("tbBName") as TextBox;
                    var author = p.FindName("tbBAuthor") as TextBox;
                    var isbn = p.FindName("tbBISBN") as TextBox;
                    var price = p.FindName("tbBPrice") as TextBox;
                    var copies = p.FindName("tbBCopy") as TextBox;

                    var book = new Book()
                    {
                        BookName = name.Text,
                        BookAuthor = author.Text,
                        BookISBN = isbn.Text,
                        BookPrice = decimal.Parse(price.Text),
                        BookCopies = int.Parse(copies.Text)
                    };
                    _unitOfWork._bookService.Add(book);
                    _unitOfWork.Save();
                    _adminBooksViewModel.AddBook(book);
                    p.Close();
                    
                } catch (Exception ex)
                {
                    MessageBox.Show("Cannot create new book!");
                }
            }); 
        }
    }
}
