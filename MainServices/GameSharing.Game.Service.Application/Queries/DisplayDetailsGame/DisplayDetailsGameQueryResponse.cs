using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame
{
    public class DisplayDetailsGameQueryResponse
    {
        public Game Game { get; set; }

        public DisplayDetailsGameQueryResponse(Game game)
        {
            Game = game;
        }
    }
}
