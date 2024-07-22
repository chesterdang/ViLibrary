using BusinessObjects;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReturnedUserService : BaseService<ReturnedUserDAO, ReturnedUser>
    {
        private readonly ReturnedUserDAO _returnedUserDAO;

        public ReturnedUserService(ReturnedUserDAO returnedUserDAO) : base(returnedUserDAO)
        {
            _returnedUserDAO = returnedUserDAO;
        }

        public void Update(ReturnedUser returnedUser)
        {
            _returnedUserDAO.Update(returnedUser);
        }
    }
}
