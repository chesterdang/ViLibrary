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
        private readonly LibraryDbContext _context;
        private readonly UserDAO _userDAO;
        private readonly BookDAO _bookDAO;
        private readonly RequestedUserDAO _requestedUserDAO;
        private readonly ReceivedUserDAO _receivedUserDAO;
        private readonly ReturnedUserDAO _returnedUserDAO;
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
