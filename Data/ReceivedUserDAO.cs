using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReceivedUserDAO : DataAccess<ReceivedUser>
    {
        private LibraryDbContext _context;
        public ReceivedUserDAO(LibraryDbContext db) : base(db) 
        {
            _context = db;
        }
        public void Update(ReceivedUser user)
        {
            _context.Update(user);
        }
    }
}
