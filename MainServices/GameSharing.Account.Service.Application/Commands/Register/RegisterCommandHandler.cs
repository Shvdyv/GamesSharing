using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.ForumService;
using GameSharing.Model.GameService;
using GameSharing.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Account.Service.Application.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IRepository<User> UserRepository;
        public RegisterCommandHandler(IRepository<User> userRepository)
        {
            userRepository = userRepository;
        }
        public Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var game = new Game();
            var user = new User(request.Id, request.Name, request.Email, request.Password, request.AuthToken);
            UserRepository.Add(user);
            return Task.CompletedTask;
        }
    }
}
