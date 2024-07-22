using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BookDAO : DataAccess<Book>
    {
        private LibraryDbContext _context;
        public BookDAO(LibraryDbContext db) : base(db) 
        {
            _context = db;
        }
        public void Update(Book book)
        {
            _context.Update(book);
        }
    }
}
