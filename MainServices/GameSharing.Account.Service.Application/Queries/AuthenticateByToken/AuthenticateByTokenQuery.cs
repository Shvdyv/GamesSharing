using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Account.Service.Application.Queries.AuthenticateByToken
{
    public class AuthenticateByTokenQuery
    {
        public Guid Token { get; set; }
        public AuthenticateByTokenQuery(Guid token)
        {
            Token = token;
        }
    }
}
