using GameSharing.Common;
using GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame;
using GameSharing.Model.GameService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Queries.DownloadGame
{
    public class DownloadGameQueryHandler : IQueryHandler<DownloadGameQuery, DownloadGameQueryResponse>
    {
        private readonly IRepository<Game> GameRepository;

        public DownloadGameQueryHandler(IRepository<Game> gameRepository)
        {
            GameRepository = gameRepository;
        }
        public async Task<DownloadGameQueryResponse> Handle(DownloadGameQuery request, CancellationToken cancellationToken)
        {
            var game = GameRepository.Get(request.Id);
            return new DownloadGameQueryResponse(game);
        }
    }
}
