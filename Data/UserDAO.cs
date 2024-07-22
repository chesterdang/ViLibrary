using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserDAO : DataAccess<User>
    {
        private LibraryDbContext _context;
        public UserDAO(LibraryDbContext db) : base(db)
        {
            _context = db;
        }
        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
