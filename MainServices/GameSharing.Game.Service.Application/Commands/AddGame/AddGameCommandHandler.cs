using GameSharing.Common;
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

        public AddGameCommandHandler(IRepository<Game> gameRepository)
        {
            GameRepository = gameRepository;
        }

        Task IRequestHandler<AddGameCommand>.Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(request.Id, request.Title, request.Description, request.Image, request.User, request.File);
            GameRepository.Add(game);
            return Task.CompletedTask;
        }
    }
}
