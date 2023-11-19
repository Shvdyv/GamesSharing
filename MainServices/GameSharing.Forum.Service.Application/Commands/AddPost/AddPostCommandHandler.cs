using GameSharing.Common;
using GameSharing.Model.ForumService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Forum.Service.Application.Commands.AddPost
{
    public class AddPostCommandHandler : ICommandHandler<AddPostCommand>
    {
        private readonly IRepository<Post> PostRepository;

        public AddPostCommandHandler(IRepository<Post> postRepository)
        {
            PostRepository = postRepository;
        }
        public Task Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            //var post = new Post(request.Id, request.Author, request.Content, request.Created);
            //PostRepository.Add(post);
            return Task.CompletedTask;
        }
    }
}
