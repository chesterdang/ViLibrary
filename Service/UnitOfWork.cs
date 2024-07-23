using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UnitOfWork
    {
        public readonly LibraryDbContext _context;
        public readonly UserDAO _userDAO;
        public readonly BookDAO _bookDAO;
        public readonly RequestedUserDAO _requestedUserDAO;
        public readonly ReceivedUserDAO _receivedUserDAO;
        public readonly ReturnedUserDAO _returnedUserDAO;
        public BookService _bookService;
        public UserService _userService;
        public RequestedUserService _requestedUserService;
        public ReceivedUserService _receivedUserService;
        public ReturnedUserService _returnedUserService;

        public UnitOfWork(LibraryDbContext context)
        {
            _context = context;
            _userDAO = new UserDAO(context);
            _bookDAO = new BookDAO(context);
            _requestedUserDAO = new RequestedUserDAO(context);
            _receivedUserDAO = new ReceivedUserDAO(context);
            _returnedUserDAO = new ReturnedUserDAO(context);
            _bookService = new BookService(_bookDAO);
            _userService = new UserService(_userDAO);
            _requestedUserService = new RequestedUserService(_requestedUserDAO);
            _receivedUserService = new ReceivedUserService(_receivedUserDAO);
            _returnedUserService = new ReturnedUserService(_returnedUserDAO);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
