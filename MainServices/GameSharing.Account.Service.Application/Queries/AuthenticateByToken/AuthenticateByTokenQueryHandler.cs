using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Account.Service.Application.Queries.AuthenticateByToken
{
    public class AuthenticateByTokenQueryHandler
    {
        //public class AuthenticateByTokenQueryHandler : IQueryHandler<AuthenticateByTokenQuery, AuthenticateByTokenQueryResponse>
        //{
        //    private readonly IRepository<User> UserRepository;
        //    public async Task<AuthenticateByTokenQueryResponse> Handle(AuthenticateByTokenQuery request, CancellationToken cancellationToken)
        //    {
        //        var user = UserRepository.Login(request.Token.ToString());
        //        var claims = UserRepository.GetClaims(user);
        //        return new AuthenticateByTokenQueryResponse(claims);
        //    }
        //}
    }
}
