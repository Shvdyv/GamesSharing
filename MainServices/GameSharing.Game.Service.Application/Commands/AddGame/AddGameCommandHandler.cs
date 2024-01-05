using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.AddGame
{
    public class AddGameCommandHandler : ICommandHandler<AddGameCommand>
    {
        private readonly IRepository<Game> GameRepository;
        private readonly IRepository<User> UserRepository;

        public AddGameCommandHandler(IRepository<Game> gameRepository, IRepository<User> userRepository)
        {
            GameRepository = gameRepository;
            UserRepository = userRepository;
        }

        Task IRequestHandler<AddGameCommand>.Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetUser(Guid.Parse(request.UserId));
            var game = new Game(request.Id, request.Title, request.Description, request.Image, user, request.File);
            GameRepository.Add(game);
            return Task.CompletedTask;
        }
    }
}
