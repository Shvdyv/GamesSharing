using GameSharing.Common;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Commands.RateGame
{
    public class RateGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public float Rate { get; set; }
        public Game Game { get; set; }

        public RateGameCommand(Guid userId, float rate, Game game)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Rate = rate;
            Game = game;
        }
    }
}
