using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using GameSharing.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.EditGame
{
    public class EditGameCommandHandler : ICommandHandler<EditGameCommand>
    {
        private readonly IRepository<Game> GameRepository;
        private readonly IRepository<User> UserRepository;

        public EditGameCommandHandler(IRepository<Game> gameRepository, IRepository<User> userRepository)
        {
            GameRepository = gameRepository;
            UserRepository = userRepository;
        }
        public Task Handle(EditGameCommand request, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetUser(Guid.Parse(request.UserId));
            var game = new Game(request.Id, request.Title, request.Description, request.Image, user, request.File);
            GameRepository.Update(game);
            return Task.CompletedTask;
        }
    }
}
