using GameSharing.Common;
using GameSharing.Model.AccountService;
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
        public User User { get; set; }
        public string File { get; set; }

        public EditGameCommand(Guid id, string title, string description, string image, User user, string file)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            User = user;
            File = file;
        }
    }
}
