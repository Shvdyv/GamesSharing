using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.AuthenticateByToken
{
    public class AuthenticateByTokenQueryResponse
    {
        public ClaimsIdentity Claims { get; set; }
        public AuthenticateByTokenQueryResponse(ClaimsIdentity claims)
        {
            Claims = claims;
        }
    }
}
