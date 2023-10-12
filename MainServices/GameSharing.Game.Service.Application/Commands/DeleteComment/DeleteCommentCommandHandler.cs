using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;
using GameSharing.GameInfo.Service.Application.Commands.DeleteGame;
using GameSharing.Model.GameService;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : ICommandHandler<DeleteCommentCommand>
    {
        private readonly IRepository<Comment> CommentRepository;

        public DeleteCommentCommandHandler(IRepository<Comment> commentRepository)
        {
            CommentRepository = commentRepository;
        }
        public Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            CommentRepository.Delete(request.Id);
            return Task.CompletedTask;
        }
    }
}
