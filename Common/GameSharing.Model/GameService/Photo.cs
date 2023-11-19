using GameSharing.Model.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.GameService
{
    public class Photo : DbDataEntity
    {
        //public Photo(Guid id, string photoUrl, Game game)
        //{
        //    Id = id;
        //    PhotoUrl = photoUrl ?? throw new ArgumentNullException(nameof(photoUrl));
        //    Game = game ?? throw new ArgumentNullException(nameof(game));
        //    IsDeleted = false;
        //}

        public string PhotoUrl { get; set; }
        public virtual Game Game { get; set; }
        public bool IsDeleted { get; set; }
    }
}
