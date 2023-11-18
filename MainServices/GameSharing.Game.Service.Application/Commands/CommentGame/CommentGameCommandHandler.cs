using GameSharing.Common;
using GameSharing.Model.GameService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.CommentGame
{
    public class CommentGameCommandHandler : ICommandHandler<CommentGameCommand>
    {
        private readonly IRepository<Comment> CommentRepository;

        public CommentGameCommandHandler(IRepository<Comment> commentRepository)
        {
            CommentRepository = commentRepository;
        }
        Task IRequestHandler<CommentGameCommand>.Handle(CommentGameCommand request, CancellationToken cancellationToken)
        {
            //var comment = new Comment(request.Id, request.Author, request.Content, request.Created, request.Game);
            //CommentRepository.Add(comment);
            return Task.CompletedTask;
        }
    }
}
