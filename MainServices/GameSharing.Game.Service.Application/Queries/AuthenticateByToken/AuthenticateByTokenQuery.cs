using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.AuthenticateByToken
{
    public class AuthenticateByTokenQuery:IQuery<AuthenticateByTokenQueryResponse>
    {
        public Guid Token { get; set; }
        public AuthenticateByTokenQuery(Guid token) 
        {
            Token = token;
        }
    }
}
