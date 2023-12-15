using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class GameRepresentation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string File { get; set; }

        public GameRepresentation(string title, string description, string image, string file)
        {
            Title = title;
            Description = description;
            Image = image;
            File = file;
        }
    }
}
