using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Admin : BaseViewModel
    {
        private int _adminId;
        private string _adminName;
        private string _adminEmail;
        private string _adminPass;

        public int AdminId { get => _adminId; set { _adminId = value; OnPropertyChanged(); } }
        public string AdminName { get => _adminName; set { _adminName = value; OnPropertyChanged(); } }
        public string AdminEmail { get => _adminEmail; set { _adminEmail = value; OnPropertyChanged(); } }
        public string AdminPass { get => _adminPass; set { _adminPass = value; OnPropertyChanged(); } }
    }
}
