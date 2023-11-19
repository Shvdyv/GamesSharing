using GameSharing.Model.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.GameService
{
    public class Game : DbDataEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } 
        public Guid Author { get; set; }
        public string FileUrl { get; set; }
        public virtual ICollection<Rate> Rates { get; set; } 
        public float Rate { get; set; }
        public int Counter { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }     
        public virtual ICollection<Photo> Photos { get; set; }

        //public Game(Guid id, string title, string description, string imageUrl, Guid author, string fileUrl)
        //{
        //    Id = id;
        //    Title = title ?? throw new ArgumentNullException(nameof(title));
        //    Description = description ?? throw new ArgumentNullException(nameof(description));
        //    ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
        //    Author = author;
        //    FileUrl = fileUrl ?? throw new ArgumentNullException(nameof(fileUrl));
        //    IsDeleted = false;
        //}
    }
}
