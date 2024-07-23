using BusinessObjects;
using Data;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminReturnViewModel : BaseViewModel
    {
        private UnitOfWork _unitOfWork;
        private ObservableCollection<ReturnedUser> _returnedUsers;
        private ObservableCollection<ReceivedUser> _receivedUsers;

        public ObservableCollection<ReturnedUser> ReturnedUsers { get { return _returnedUsers; } set { _returnedUsers = value; OnPropertyChanged(); } }
        private ObservableCollection<ReceivedUser> ReceivedUsers { get { return _receivedUsers; } set { _receivedUsers = value; OnPropertyChanged(); } }
        public ICommand LoadCommand { get; set; }
        public ICommand AcceptCommand { get; set; }

        public AdminReturnViewModel(LibraryDbContext _context)
        {
            _unitOfWork = new UnitOfWork(_context);
            _returnedUsers = new ObservableCollection<ReturnedUser>(_unitOfWork._returnedUserService.GetAll());
            _receivedUsers = new ObservableCollection<ReceivedUser>(_unitOfWork._receivedUserService.GetAll());
            AcceptCommand = new RelayCommand<ReturnedUser>(
                request => request != null,
                request => AcceptRequest(request)
            );

        }
        private void AcceptRequest(ReturnedUser request)
        {
            if (request == null) return;

            Book b = _unitOfWork._bookService.Get(book => book.BookId == request.BookId);
            b.BookCopies += 1;
            _unitOfWork._bookService.Update(b);
            
            ReceivedUser received = _unitOfWork._receivedUserService.Get(book => book.BookId == request.BookId && book.UserId == request.UserId);
            _unitOfWork._returnedUserService.Delete(request);
            _unitOfWork._receivedUserService.Delete(received);
            _unitOfWork.Save();
            _returnedUsers.Remove(request);
            _receivedUsers.Remove(received);
        }
    }
}
