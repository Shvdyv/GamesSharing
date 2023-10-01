using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class CommentGameRepresentation
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid Author { get; set; }
        public DateTime Created { get; set; }
        public Game Game { get; set; }

        public CommentGameRepresentation(Guid id, string content, Guid author, DateTime created, Game game)
        {
            Id = id;
            Content = content;
            Author = author;
            Created = created;
            Game = game;
        }
    }
}
