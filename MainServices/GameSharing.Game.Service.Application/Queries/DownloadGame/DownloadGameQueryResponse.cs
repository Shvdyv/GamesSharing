using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.DownloadGame
{
    public class DownloadGameQueryResponse
    {
        public Game Game { get; set; }

        public DownloadGameQueryResponse(Game game)
        {
            Game = game;
        }
    }
}
