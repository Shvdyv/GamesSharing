using GameSharing.Common;
using GameSharing.Model.AccountService;
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
        private readonly IRepository<User> UserRepository;

        public CommentGameCommandHandler(IRepository<Comment> commentRepository, IRepository<User> userRepository)
        {
            CommentRepository = commentRepository;
            UserRepository = userRepository;
        }
        Task IRequestHandler<CommentGameCommand>.Handle(CommentGameCommand request, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetUser(Guid.Parse(request.UserId));
            var comment = new Comment(request.Id, user, request.Content, request.Created, request.Game);
            CommentRepository.Add(comment);
            return Task.CompletedTask;
        }
    }
}
