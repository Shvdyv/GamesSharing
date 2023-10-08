using GameSharing.Common;
using GameSharing.Model.ForumService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;
using GameSharing.Common;
using GameSharing.Model.AccountService;

namespace GameSharing.Account.Service.Application.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IRepository<User> UserRepository;

        public LoginCommandHandler(IRepository<User> userRepository)
        {
            UserRepository = userRepository;
        }
        public Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
