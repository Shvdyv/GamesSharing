using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service
{
    public class AddPhotosRepresentation
    {
        public string Photo { get; set; }
        public Game Game { get; set; }


        public AddPhotosRepresentation(string photo, Game game)
        {
            Photo = photo;
            Game = game;
        }
    }
}
