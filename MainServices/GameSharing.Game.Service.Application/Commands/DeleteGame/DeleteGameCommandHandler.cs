using GameSharing.Common;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : ICommandHandler<DeleteGameCommand>
    {
        private readonly IRepository<Game> GameRepository;

        public DeleteGameCommandHandler(IRepository<Game> gameRepository)
        {
            GameRepository = gameRepository;
        }
        public Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        { 
            GameRepository.Delete(request.Id);
            return Task.CompletedTask;
        }
    }
}
