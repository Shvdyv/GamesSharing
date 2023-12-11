using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class GameRepresentation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid Author { get; set; }
        public string File { get; set; }

        public GameRepresentation(string title, string description, string image, Guid author, string file)
        {
            Title = title;
            Description = description;
            Image = image;
            Author = author;
            File = file;
        }
    }
}
