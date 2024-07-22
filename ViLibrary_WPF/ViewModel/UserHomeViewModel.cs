using BusinessObjects;
using Data;
using FrameWPF.ViewModel;
using LibraryManagementSystem;
using Microsoft.Identity.Client.NativeInterop;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViLibrary_WPF.ViewModel
{
    public class UserHomeViewModel : BaseViewModel
    {
        public UserService _userService { get; set; }
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;
        private ObservableCollection<Book> books;
        private int id;
        private string name;
        private string author;
        private string isbn;
        private decimal price;
        private int copies;
        private Book selectedBook;
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged();
            }
        }

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged();
                if (selectedBook != null)
                {
                    Id = selectedBook.BookId;
                    Name = selectedBook.BookName;
                    Author = selectedBook.BookAuthor;
                    ISBN = selectedBook.BookISBN;
                    Price = selectedBook.BookPrice;
                    Copies = selectedBook.BookCopies;
                }
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }

        public string ISBN
        {
            get { return isbn; }
            set
            {
                isbn = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public int Copies
        {
            get { return copies; }
            set
            {
                copies = value;
                OnPropertyChanged();
            }
        }
      
        public ICommand Transaction { get; set; }
        public ICommand Logout { get; set; }
        public ICommand Request { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UserHomeViewModel()
        {
            _unitOfWork = new UnitOfWork(_context);
            books = new ObservableCollection<Book>(_unitOfWork._bookService.GetAll());
            Request = new RelayCommand<Book>(CanRequest, ExecuteRequest);
            Transaction = new RelayCommand<Window>(p=>true, ExecuteTransaction);
        }
        private void ExecuteTransaction(Window parentWindow)
        {
            var transactionWindow = new Window
            {
                Title = "Transaction Details",
                Width = 800,
                Height = 450,
                Content = new UserTransaction() 
            };

            transactionWindow.Owner = parentWindow;
            transactionWindow.ShowDialog();
        }
        private bool CanRequest(Book book)
        {
            
            return book != null && book.BookId > 0;
        }
        private void ExecuteRequest(Book book)
        {
            try
            {
                var requestedUser = new RequestedUser()
                {
                    BookId = book.BookId,
                    UserId = 2,
                    BookName = book.BookName,
                    DateRequested = DateTime.Now,
                    UserName = "User Two",
        };

                _unitOfWork._requestedUserService.Add(requestedUser);
                _unitOfWork.Save();
                MessageBox.Show("Book requested successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot request book: " + ex.Message);
            }
        }
    }
}
