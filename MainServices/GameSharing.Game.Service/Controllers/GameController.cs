using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Reflection;
using GameSharing.GameInfo.Service.Application.Commands.AddGame;
using GameSharing.GameInfo.Service.Application.Commands.DeleteGame;
using GameSharing.GameInfo.Service.Application.Commands.CommentGame;
using GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame;
using GameSharing.GameInfo.Service.Application.Queries.DownloadGame;
using GameSharing.GameInfo.Service.Application.Commands.EditGame;
using GameSharing.GameInfo.Service.Application.Commands.RateGame;
using GameSharing.GameInfo.Service.Application.Commands.AddPhotos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using GameSharing.GameInfo.Service.Application.Queries.GetAllGames;
using GameSharing.Model.GameService;

namespace GameSharing.GameInfo.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator mediator;

        public GameController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] GameRepresentation gameRepresantation)
        {
            await mediator.Send(new AddGameCommand(gameRepresantation.Id, gameRepresantation.Title, gameRepresantation.Description, gameRepresantation.Image, gameRepresantation.Author, gameRepresantation.File, gameRepresantation.Rate));
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteGame([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteGameCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditGame([FromBody] GameRepresentation gameRepresantation)
        {
            await mediator.Send(new EditGameCommand(gameRepresantation.Id, gameRepresantation.Title, gameRepresantation.Description, gameRepresantation.Image, gameRepresantation.Author, gameRepresantation.File));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var result = await mediator.Send(new GetAllGamesQuery());
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> DisplayDetailsGame([FromRoute] Guid id, string title, string description, string image, string author, string file, string comment, float rate)
        {
            var result = await mediator.Send(new DisplayDetailsGameQuery(id, title, description, image, author, file, comment, rate));
            return Ok(); // po id
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> DownloadGame([FromRoute] Guid id, string file)
        {
            var result = await mediator.Send(new DownloadGameQuery(id, file)); 
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CommentGame([FromBody] CommentGameRepresentation commentGameRepresentation)
        {
            await mediator.Send(new CommentGameCommand(commentGameRepresentation.Id, commentGameRepresentation.Content, commentGameRepresentation.Author, commentGameRepresentation.Created, commentGameRepresentation.Game));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RateGame([FromBody] RateGameRepresentation rateGameRepresentation)
        {
            await mediator.Send(new RateGameCommand(rateGameRepresentation.Id, rateGameRepresentation.UserId, rateGameRepresentation.Rate, rateGameRepresentation.Game));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotos([FromBody] AddPhotosRepresentation addPhotosRepresentation)
        {
            await mediator.Send(new AddPhotosCommand(addPhotosRepresentation.Photo, addPhotosRepresentation.Game));
            return Ok();
        }

    }
}
