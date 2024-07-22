using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Book : BaseViewModel
    {
        private int _bookId;
        private string _bookName;
        private string _bookAuthor;
        private string _bookISBN;
        private decimal _bookPrice;
        private int _bookCopies;

        public int BookId { get => _bookId; set { _bookId = value; OnPropertyChanged(); } }
        public string BookName { get => _bookName; set { _bookName = value; OnPropertyChanged(); } }
        public string BookAuthor { get => _bookAuthor; set { _bookAuthor = value; OnPropertyChanged(); } }
        public string BookISBN { get => _bookISBN; set { _bookISBN = value; OnPropertyChanged(); } }
        public decimal BookPrice { get => _bookPrice; set { _bookPrice = value; OnPropertyChanged(); } }
        public int BookCopies { get => _bookCopies; set { _bookCopies = value; OnPropertyChanged(); } }

        // Navigation properties
        public virtual ICollection<ReturnedUser> ReturnedUsers { get; set; }
        public virtual ICollection<ReceivedUser> ReceivedUsers { get; set; }
        public virtual ICollection<RequestedUser> RequestedUsers { get; set; }
    }
}
