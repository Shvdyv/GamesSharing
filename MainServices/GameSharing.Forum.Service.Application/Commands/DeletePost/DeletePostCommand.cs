using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Forum.Service.Application.Commands.DeletePost
{
    public class DeletePostCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeletePostCommand(Guid id)
        {
            Id = id;
        }
    }
}
