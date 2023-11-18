using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.GameService
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid Author { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        //public Comment(Guid id, Guid author, string content, DateTime created, Game game)
        //{
        //    Id = id;
        //    Author = author;
        //    Content = content ?? throw new ArgumentNullException(nameof(content));
        //    Created = created;
        //    Game = game ?? throw new ArgumentNullException(nameof(game));
        //}

        public virtual Game Game { get; set; }
    }
}
