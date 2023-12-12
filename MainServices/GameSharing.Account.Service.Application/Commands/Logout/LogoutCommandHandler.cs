using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.ForumService;
using GameSharing.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Account.Service.Application.Commands.Logout
{
    public class LogoutCommandHandler : ICommandHandler<LogoutCommand>
    {
        public LogoutCommandHandler(IRepository<User> userRepository)
        {
            userRepository = userRepository;
        }
        public Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }
    }
}
