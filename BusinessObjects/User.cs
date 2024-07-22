using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User : BaseViewModel
    {
        private int _userId;
        private string _userName;
        private string _userPass;
        private string _userEmail;
        private string _userAdNo;
        public int UserId { get => _userId; set { _userId = value; OnPropertyChanged(); } }
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }
        public string UserAdNo { get => _userAdNo; set { _userAdNo = value; OnPropertyChanged(); } }
        public string UserEmail { get => _userEmail; set { _userEmail = value; OnPropertyChanged(); } }
        public string UserPass { get => _userPass; set { _userPass = value; OnPropertyChanged(); } }

        // Navigation properties
        public virtual ICollection<ReturnedUser> ReturnedUsers { get; set; }
        public virtual ICollection<ReceivedUser> ReceivedUsers { get; set; }
        public virtual ICollection<RequestedUser> RequestedUsers { get; set; }
    }

}
