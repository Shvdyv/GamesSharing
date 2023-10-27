using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class GameRepresentation
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid Author { get; set; }
        public string File { get; set; }
        //public Rate Rate { get; set; }

        public GameRepresentation(Guid id, string title, string description, string image, Guid author, string file/*, Rate rate*/)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Author = author;
            File = file;
            //Rate = rate;
        }
    }
}
