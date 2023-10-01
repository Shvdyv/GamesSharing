using GameSharing.Model.ForumService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Forum.Service.Application.Queries.DisplayPosts
{
    public class DisplayPostsQueryResponse
    {
        public IEnumerable<Post> Posts { get; set; }

        public DisplayPostsQueryResponse(IEnumerable<Post> posts)
        {
            Posts = posts;
        }
    }
}
