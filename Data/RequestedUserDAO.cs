using Azure.Core;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RequestedUserDAO : DataAccess<RequestedUser>
    {
        private LibraryDbContext _context;
        public RequestedUserDAO(LibraryDbContext db) : base(db)
        {
            _context = db;
        }
        public void Update (RequestedUser user)
        {
            _context.Update(user);
        }
    }
}
