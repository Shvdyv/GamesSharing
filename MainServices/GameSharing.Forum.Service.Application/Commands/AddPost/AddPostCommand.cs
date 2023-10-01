using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Forum.Service.Application.Commands.AddPost
{
    public class AddPostCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }

        public AddPostCommand(string author, string content)
        {
            Id = Guid.NewGuid();
            Author = author;
            Created = DateTime.Now;
            Content = content;
        }
    }
}
