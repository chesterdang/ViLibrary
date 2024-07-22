using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ReturnedUser : BaseViewModel
    {
        private int _bookId;
        private string _bookName;
        private DateTime _dateReturned;
        private int _userId;
        private string _userName;

        public int BookId { get => _bookId; set { _bookId = value; OnPropertyChanged(); } }
        public string BookName { get => _bookName; set { _bookName = value; OnPropertyChanged(); } }
        public DateTime DateReturned { get => _dateReturned; set { _dateReturned = value; OnPropertyChanged(); } }
        public int UserId { get => _userId; set { _userId = value; OnPropertyChanged(); } }
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
