using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Account.Service.Application.Queries.Authenticate
{
    public class AuthenticateQuery : IQuery<AuthenticateQueryResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AuthenticateQuery(string login, string password) 
        { 
            Login = login;
            Password = password;
        }
    }
}
