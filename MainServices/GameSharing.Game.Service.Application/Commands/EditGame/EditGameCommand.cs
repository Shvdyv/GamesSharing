using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameSharing.GameInfo.Service.Application.Commands.EditGame
{
    public class EditGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid Author { get; set; }
        public string File { get; set; }

        public EditGameCommand(Guid id, string title, string description, string image, Guid author, string file)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Author = author;
            File = file;
        }
    }
}
