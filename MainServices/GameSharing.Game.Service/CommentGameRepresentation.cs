using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class CommentGameRepresentation
    {
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Game Game { get; set; }

        public CommentGameRepresentation(string content, DateTime created, Game game)
        {
            Content = content;
            Created = created;
            Game = game;
        }
    }
}
