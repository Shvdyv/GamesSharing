using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;
using GameSharing.Model.GameService;
using MediatR;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Queries.GetAllGames
{
    public class GetAllGamesQueryHandler : IQueryHandler<GetAllGamesQuery, GetAllGamesQueryResponse>
    {
        private readonly IRepository<Game> GameRepository;

        public GetAllGamesQueryHandler(IRepository<Game> gameRepository)
        {
            GameRepository = gameRepository;
        }

        public async Task<GetAllGamesQueryResponse> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = GameRepository.GetAll();
            return new GetAllGamesQueryResponse(games);
        }
    }
}
