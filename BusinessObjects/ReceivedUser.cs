using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ReceivedUser : BaseViewModel
    {
        private int _bookId;
        private string _bookName;
        private DateTime _dateReceived;
        private int _userId;
        private string _userName;

        public int BookId { get => _bookId; set { _bookId = value; OnPropertyChanged(); } }
        public string BookName { get => _bookName; set { _bookName = value; OnPropertyChanged(); } }
        public DateTime DateReceived { get => _dateReceived; set { _dateReceived = value; OnPropertyChanged(); } }
        public int UserId { get => _userId; set { _userId = value; OnPropertyChanged(); } }
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
