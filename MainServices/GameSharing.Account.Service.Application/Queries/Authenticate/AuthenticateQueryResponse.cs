using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Account.Service.Application.Queries.Authenticate
{
    public class AuthenticateQueryResponse
    {
        public ClaimsIdentity Claims { get; set; }
        public AuthenticateQueryResponse(ClaimsIdentity claims)
        {
            Claims = claims;
        }
    }
}
