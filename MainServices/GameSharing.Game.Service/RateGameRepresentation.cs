using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class RateGameRepresentation
    {
        public Guid UserId { get; set; }
        public float Rate { get; set; }
        public Game Game { get; set; }

        public RateGameRepresentation(Guid userId, float rate, Game game)
        {
            UserId = userId;
            Rate = rate;
            Game = game;
        }
    }
}
