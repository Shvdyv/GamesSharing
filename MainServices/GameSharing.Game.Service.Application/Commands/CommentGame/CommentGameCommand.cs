using GameSharing.Common;
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
        public Guid Author { get; set; }
        public DateTime Created { get; set; }
        public Game Game { get; set; } 

        public CommentGameCommand(string content, Guid author, DateTime created, Game game)
        {
            Id = Guid.NewGuid();
            Content = content;
            Author = author;
            Created = created;
            Game = game;
        }
    }
}
