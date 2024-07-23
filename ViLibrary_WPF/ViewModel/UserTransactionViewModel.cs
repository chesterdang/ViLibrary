using BusinessObjects;
using Data;
using Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ViLibrary_WPF.ViewModel
{
    public class UserTransactionViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;

        private ObservableCollection<RequestedUser> requestedBooks;
        private ObservableCollection<ReceivedUser> receivedBooks;

        public ObservableCollection<RequestedUser> RequestedBooks
        {
            get { return requestedBooks; }
            set
            {
                requestedBooks = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReceivedUser> ReceivedBooks
        {
            get { return receivedBooks; }
            set
            {
                receivedBooks = value;
                OnPropertyChanged();
            }
        }

        public ICommand Returned { get; set; }

        public UserTransactionViewModel(User user)
        {
            _unitOfWork = new UnitOfWork(_context);
            LoadData(user);

            Returned = new RelayCommand<ReceivedUser>(r => true, r =>
            {
                try
                {
                    var returnedBookUser = new ReturnedUser()
                    {
                        BookId = r.BookId,
                        UserId = user.UserId,
                        BookName = r.BookName,
                        DateReturned = DateTime.Now,
                        UserName = user.UserName,
                    };

                    _unitOfWork._returnedUserService.Add(returnedBookUser);
                    _unitOfWork.Save();
                    MessageBox.Show("Book returned successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot receieved book, because you sent a request to admin!");
                }
            });
        }

        private void LoadData(User user)
        {
            RequestedBooks = new ObservableCollection<RequestedUser>(_unitOfWork._requestedUserService.GetAll().Where(r => r.UserId == user.UserId));
            ReceivedBooks = new ObservableCollection<ReceivedUser>(_unitOfWork._receivedUserService.GetAll().Where(r => r.UserId == user.UserId));
        }
    }
}
