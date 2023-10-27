using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class CommentGameRepresentation
    {
        public string Content { get; set; }
        public Guid Author { get; set; }
        public DateTime Created { get; set; }
        public Game Game { get; set; }

        public CommentGameRepresentation(string content, Guid author, DateTime created, Game game)
        {
            Content = content;
            Author = author;
            Created = created;
            Game = game;
        }
    }
}
