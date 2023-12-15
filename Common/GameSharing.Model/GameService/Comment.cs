using GameSharing.Model.AccountService;
using GameSharing.Model.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.GameService
{
    public class Comment : DbDataEntity
    {
        public virtual User User { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public virtual Game Game { get; set; }
        public bool IsDeleted { get; set; }
        public Comment(Guid id, User user, string content, DateTime created, Game game)
        {
            Id = id;
            User = user;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Created = created;
            Game = game ?? throw new ArgumentNullException(nameof(game));
            IsDeleted = false;
        }

        public Comment() { }
    }
}
