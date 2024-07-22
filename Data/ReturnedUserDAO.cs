using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReturnedUserDAO : DataAccess<ReturnedUser>
    {
        private LibraryDbContext _context;
        public ReturnedUserDAO(LibraryDbContext db) : base(db)
        {
            _context = db;
        }
        public void Update(ReturnedUser user)
        {
            _context.Update(user);
        }
    }
}
