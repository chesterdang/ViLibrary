using BusinessObjects;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : BaseService<UserDAO, User>
    {
        private UserDAO userDAO;
        public UserService(UserDAO dao) : base(dao)
        {
            userDAO = dao;
        }
        public void Update(User user)
        {
            userDAO.Update(user);
        }
    }
}
