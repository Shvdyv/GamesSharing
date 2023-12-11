using GameSharing.Common;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Queries.AuthenticateByToken
{
    public class AuthenticateByTokenQueryHandler : IQueryHandler<AuthenticateByTokenQuery, AuthenticateByTokenQueryResponse>
    {
        private readonly IRepository<Game> GameRepository;
        public async Task<AuthenticateByTokenQueryResponse> Handle(AuthenticateByTokenQuery request, CancellationToken cancellationToken)
        {
            var user = GameRepository.Login(request.Token.ToString());
            var claims = GameRepository.GetClaims(user);
            return new AuthenticateByTokenQueryResponse(claims);
        }
    }
}
