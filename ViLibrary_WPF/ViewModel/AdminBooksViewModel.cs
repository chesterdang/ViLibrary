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
    public class AdminBooksViewModel : BaseViewModel
    {
        private UnitOfWork _unitOfWork;


        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books { get { return books; } set { books = value; OnPropertyChanged(); } }

        public ICommand Add { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }

        public AdminBooksViewModel(LibraryDbContext _context)
        {
            _unitOfWork = new UnitOfWork(_context);
            books = new ObservableCollection<Book>(_unitOfWork._bookService.GetAll());
            Add = new RelayCommand<UserControl>(p => true, p =>
            {
                var addBookWindow = new AdminAddBook(_context);
                var addBookVM = new AdminAddBookViewModel(this,_context);
                addBookWindow.DataContext = addBookVM;
                addBookWindow.Show();
            });
            Edit = new RelayCommand<Book>(p => true, p =>
            {
                var updateWindow = new AdminUpdateBook();
                updateWindow.DataContext = new AdminUpdateBookViewModel(p, _context);
                updateWindow.Show();
            });
            Delete = new RelayCommand<Book>(p => true, p =>
            {
                MessageBoxResult rs = MessageBox.Show($"Do you want to delete the book with name {p.BookName}",
                    "Book Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (rs == MessageBoxResult.Yes)
                {
                    _unitOfWork._bookService.Delete(p);
                    _unitOfWork.Save();
                    books.Remove(p);
                    OnPropertyChanged(nameof(Books));
                }
            });
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            OnPropertyChanged(nameof(Books));
        }
    }
}
