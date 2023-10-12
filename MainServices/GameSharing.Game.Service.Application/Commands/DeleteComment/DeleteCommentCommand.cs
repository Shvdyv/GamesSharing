using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;

namespace GameSharing.GameInfo.Service.Application.Commands.DeleteComment
{
    public class DeleteCommentCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteCommentCommand(Guid id)
        {
            Id = id;
        }
    }
}
