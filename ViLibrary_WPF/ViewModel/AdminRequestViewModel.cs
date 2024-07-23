using BusinessObjects;
using Data;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViLibrary_WPF.ViewModel
{
    public class AdminRequestViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;
        private ObservableCollection<RequestedUser> _requestedUsers;

        public ObservableCollection<RequestedUser> RequestedUsers { get { return _requestedUsers; } set { _requestedUsers = value; OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand RejectCommand { get; set; }

        public AdminRequestViewModel()
        {
            _unitOfWork = new UnitOfWork(_context);
            _requestedUsers = new ObservableCollection<RequestedUser>(_unitOfWork._requestedUserService.GetAll());
            AcceptCommand = new RelayCommand<RequestedUser>(
                request => request != null,
                request => AcceptRequest(request)
            );

            RejectCommand = new RelayCommand<RequestedUser>(
                request => request != null,
                request => RejectRequest(request)
            );
        }
        private void AcceptRequest(RequestedUser request)
        {
            if (request == null) return;

            _unitOfWork._requestedUserService.Delete(request);
            _unitOfWork._receivedUserService.Add(new ReceivedUser { BookId = request.BookId,UserId = request.UserId,BookName = request.BookName,DateReceived = DateTime.Now,UserName = request.UserName});     
            Book b = _unitOfWork._bookService.Get(book => book.BookId == request.BookId);
            b.BookCopies -= 1;
            _unitOfWork._bookService.Update(b);
            _unitOfWork.Save();
            _requestedUsers.Remove(request);
        }

        private void RejectRequest(RequestedUser request)
        {
            if (request == null) return;
            _unitOfWork._requestedUserService.Delete(request);
            _unitOfWork.Save();
            _requestedUsers.Remove(request);
        }
    }
}
