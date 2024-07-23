using BusinessObjects;
using Data;
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
    public class UserBorrowViewModel : BaseViewModel
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

        public ICommand Request { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UserBorrowViewModel(User user)
        {   
            _unitOfWork = new UnitOfWork(_context);
            books = new ObservableCollection<Book>(_unitOfWork._bookService.GetAll().Where(b => b.BookCopies > 0));
            Request = new RelayCommand<Book>(b=>true, b =>
            { 
                try
                {
                    var requestedUser = new RequestedUser()
                    {
                        BookId = b.BookId,
                        UserId = user.UserId,
                        BookName = b.BookName,
                        DateRequested = DateTime.Now,
                        UserName = user.UserName,
                    };

                    _unitOfWork._requestedUserService.Add(requestedUser);
                    _unitOfWork.Save();
                    MessageBox.Show("Book requested successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot request book, because you sent a request to admin!");
                }
            });
           
        }
       
      

    }
}
