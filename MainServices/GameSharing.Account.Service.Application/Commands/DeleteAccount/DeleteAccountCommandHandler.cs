using GameSharing.Common;
using GameSharing.Model.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Account.Service.Application.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand>
    {
        private readonly IRepository<User> UserRepository;

        public DeleteAccountCommandHandler(IRepository<User> userRepository)
        {
            UserRepository = userRepository;
        }
        public Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            UserRepository.Delete(request.Id);
            return Task.CompletedTask;
        }
    }
}
