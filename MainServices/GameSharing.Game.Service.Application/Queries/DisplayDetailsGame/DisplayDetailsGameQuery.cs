using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame
{
    public class DisplayDetailsGameQuery : IQuery<DisplayDetailsGameQueryResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public string File { get; set; }
        public string Comment { get; set; }
        public float Rate { get; set; }

        public DisplayDetailsGameQuery(Guid id, string title, string description, string image, string author, string file, string comment, float rate)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Author = author;
            File = file;
            Comment = comment;
            Rate = rate;
        }
    }
}
