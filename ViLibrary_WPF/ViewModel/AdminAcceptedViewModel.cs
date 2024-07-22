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
    public class AdminAcceptedViewModel : BaseViewModel
    {
        private LibraryDbContext _context = new LibraryDbContext();
        private UnitOfWork _unitOfWork;
        private ObservableCollection<ReceivedUser> _receivedUsers;

        public ObservableCollection<ReceivedUser> ReceivedUsers { get { return _receivedUsers; } set { _receivedUsers = value; OnPropertyChanged(); } }

        public ICommand LoadCommand { get; set; }
        public AdminAcceptedViewModel()
        {
            _unitOfWork = new UnitOfWork(_context);
            _receivedUsers = new ObservableCollection<ReceivedUser>(_unitOfWork._receivedUserService.GetAll());

        }
    }
}
