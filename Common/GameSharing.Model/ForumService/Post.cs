using GameSharing.Model.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.ForumService
{
    public class Post : DbDataEntity
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }

        public Post(Guid id, string author, string content, DateTime created)
        {
            Id = id;
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Created = created;
        }

        public Post() { }
    }
}
