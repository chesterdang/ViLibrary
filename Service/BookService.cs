using BusinessObjects;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService : BaseService<BookDAO, Book>
    {
        private readonly BookDAO _bookDAO;

        public BookService(BookDAO bookDAO) : base(bookDAO)
        {
            _bookDAO = bookDAO;
        }

        public void Update(Book book)
        {
            _bookDAO.Update(book);
        }
    }
}
