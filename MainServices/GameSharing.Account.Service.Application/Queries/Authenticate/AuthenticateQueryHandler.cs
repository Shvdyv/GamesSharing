using GameSharing.Common;
using GameSharing.Model.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Account.Service.Application.Queries.Authenticate
{
    public class AuthenticateQueryHandler : IQueryHandler<AuthenticateQuery, AuthenticateQueryResponse>
    {
        private readonly IRepository<User> UserRepository;
        public async Task<AuthenticateQueryResponse> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var user = UserRepository.Login(request.Login, request.Password);
            var claims = UserRepository.GetClaims(user);
            return new AuthenticateQueryResponse(claims);
        }
    }
}
