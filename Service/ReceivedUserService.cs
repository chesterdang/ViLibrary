using BusinessObjects;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReceivedUserService : BaseService<ReceivedUserDAO, ReceivedUser>
    {
        private readonly ReceivedUserDAO _receivedUserDAO;

        public ReceivedUserService(ReceivedUserDAO receivedUserDAO) : base(receivedUserDAO)
        {
            _receivedUserDAO = receivedUserDAO;
        }

        public void Update(ReceivedUser receivedUser)
        {
            _receivedUserDAO.Update(receivedUser);
        }
    }
}
