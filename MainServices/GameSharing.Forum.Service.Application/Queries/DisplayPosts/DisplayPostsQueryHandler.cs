using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;
using GameSharing.Model.ForumService;
using GameSharing.Repository.Repositories;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Forum.Service.Application.Queries.DisplayPosts
{
    public class DisplayPostsQueryHandler : IQueryHandler<DisplayPostsQuery, DisplayPostsQueryResponse>
    {
        private readonly IRepository<Post> PostRepository;

        public DisplayPostsQueryHandler(IRepository<Post> postRepository)
        {
            PostRepository = postRepository;
        }
        public async Task<DisplayPostsQueryResponse> Handle(DisplayPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = PostRepository.GetAll();
            return new DisplayPostsQueryResponse(posts);
        }
    }
}
