using BusinessObjects;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RequestedUserService : BaseService<RequestedUserDAO, RequestedUser>
    {
        private readonly RequestedUserDAO _requestedUserDAO;

        public RequestedUserService(RequestedUserDAO requestedUserDAO) : base(requestedUserDAO)
        {
            _requestedUserDAO = requestedUserDAO;
        }

        public void Update(RequestedUser requestedUser)
        {
            _requestedUserDAO.Update(requestedUser);
        }
    }
}
