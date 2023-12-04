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
using GameSharing.GameInfo.Service.Application.Commands.DeleteComment;
using GameSharing.GameInfo.Service.Application.Commands.DeleteRate;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using GameSharing.GameInfo.Service.Application.Queries.GetAllGames;
using GameSharing.Model.GameService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GameSharing.GameInfo.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IMediator mediator;

        public GameController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AuthenticateByToken(string token)
        {
            NetAuthService.AuthService auth = new AuthService(_context);
            var user = auth.Login(token);
            if (user != null)
            {
                var claims = auth.GetClaims(user);
                var principal = new ClaimsPrincipal(claims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Ok();
            }
            return StatusCode(403);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] GameRepresentation gameRepresantation)
        {
            await mediator.Send(new AddGameCommand(gameRepresantation.Title, gameRepresantation.Description, gameRepresantation.Image, gameRepresantation.Author, gameRepresantation.File));
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var result = await mediator.Send(new GetAllGamesQuery());
            return Ok();
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> DisplayDetailsGame([FromRoute] Guid id)
        {
            var result = await mediator.Send(new DisplayDetailsGameQuery(id));
            return Ok();
        }

        [AllowAnonymous]
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
            await mediator.Send(new CommentGameCommand(commentGameRepresentation.Content, commentGameRepresentation.Author, commentGameRepresentation.Created, commentGameRepresentation.Game));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RateGame([FromBody] RateGameRepresentation rateGameRepresentation)
        {
            await mediator.Send(new RateGameCommand(rateGameRepresentation.UserId, rateGameRepresentation.Rate, rateGameRepresentation.Game));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotos([FromBody] AddPhotosRepresentation addPhotosRepresentation)
        {
            await mediator.Send(new AddPhotosCommand(addPhotosRepresentation.Photo, addPhotosRepresentation.Game));
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRate([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteRateCommand(id));
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteCommentCommand(id));
            return Ok();
        }
    }
}
