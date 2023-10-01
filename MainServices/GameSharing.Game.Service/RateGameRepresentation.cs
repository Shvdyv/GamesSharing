using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class RateGameRepresentation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public float Rate { get; set; }
        public Game Game { get; set; }

        public RateGameRepresentation(Guid id, Guid userId, float rate, Game game)
        {
            Id = id;
            UserId = userId;
            Rate = rate;
            Game = game;
        }
    }
}
