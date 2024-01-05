using GameSharing.Model.Prototype;
using GameSharing.Model.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.GameService
{
    public class Rate : DbDataEntity
    {
        public virtual User User { get; set; }
        public float GameRate { get; set; }
        public virtual Game Game { get; set; }
        public bool IsDeleted { get; set; }

        public Rate(Guid id, User user, float gameRate, Game game)
        {
            Id = id;
            User = user;
            GameRate = gameRate;
            Game = game ?? throw new ArgumentNullException(nameof(game));
            IsDeleted = false;
        }

        public Rate() { }
    }
}
