using GameSharing.Common;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Commands.AddPhotos
{
    public class AddPhotosCommand : ICommand
    {
        public string Photo { get; set; } // List, ICollection?
        public Game Game { get; set; }

        public AddPhotosCommand(string photo, Game game)
        {
            Photo = photo;
            Game = game;
        }
    }
}
