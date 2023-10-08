using GameSharing.Common;
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
        public Guid Author { get; set; }
        public string File { get; set; }
        //public Rate Rate { get; set; }
        public Game Game { get; set; }

        public AddGameCommand(Guid id, string title, string description, string image, Guid author, string file /*Rate rate*/)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Author = author;
            File = file;
            //Rate = rate;
        }
    }
}
