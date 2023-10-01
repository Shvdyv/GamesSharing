using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Commands.DeleteGame
{
    public class DeleteGameCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteGameCommand(Guid id)
        {
            Id = id;
        }
    }
}
