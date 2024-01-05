using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Commands.CommentGame
{
    public class CommentGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public Game Game { get; set; } 

        public CommentGameCommand(string content, string userId, DateTime created, Game game)
        {
            Id = Guid.NewGuid();
            Content = content;
            UserId = userId;
            Created = created;
            Game = game;
        }
    }
}
