using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.GetAllGames
{
    public class GetAllGamesQueryResponse
    {
        public IEnumerable<Game> Games { get; set; }

        public GetAllGamesQueryResponse(IEnumerable<Game> games)
        {
            Games = games;
        }
    }
}
