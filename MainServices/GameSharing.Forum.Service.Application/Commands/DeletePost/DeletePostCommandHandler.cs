using GameSharing.Common;
using GameSharing.Model.ForumService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Forum.Service.Application.Commands.DeletePost
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly IRepository<Post> PostRepository;

        public DeletePostCommandHandler(IRepository<Post> postRepository)
        {
            PostRepository = postRepository;
        }
        public Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            PostRepository.Delete(request.Id);
            return Task.CompletedTask;
        }
    }
}
