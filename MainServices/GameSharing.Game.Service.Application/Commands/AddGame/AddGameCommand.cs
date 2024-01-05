using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameSharing.GameInfo.Service.Application.Commands.AddGame
{
    public class AddGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public string File { get; set; }
        public Game Game { get; set; }

        public AddGameCommand(string title, string description, string image, string userId, string file)

        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Image = image;
            UserId = userId;
            File = file;
        }
    }
}
