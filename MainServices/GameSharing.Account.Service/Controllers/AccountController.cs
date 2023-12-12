using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using NetAuthService;
using GameSharing.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using GameSharing.Account.Service.Application.Queries.AuthenticateByToken;
using GameSharing.Account.Service.Application.Queries.Authenticate;
using GameSharing.Account.Service.Application.Commands.Logout;
using GameSharing.Account.Service.Application.Commands.Register;

namespace GameSharing.Account.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly Database _context;

        public AccountController(IMediator mediator,Database database)
        {
            this.mediator = mediator;
            _context = database;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Authenticate(string login, string password)
        {
            var claims = await mediator.Send(new AuthenticateQuery(login, password));
            //NetAuthService.AuthService auth = new AuthService(_context);
            //var user = auth.Login(login, password);
            //if (user != null)
            //{
            //var claims = auth.GetClaims(user);
                var principal = new ClaimsPrincipal(claims.Claims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            //return Ok(new { token = user.AuthToken});
            return Ok();
            //}
            return StatusCode(403);
        }
        //Każdy kontroller musi mieć zaimplementowaną tą funkcje i jeżeli Api zwraca 403 powinno się to uruchomić dla każdego serwisu wtedy każdy serwis do requesta zwrotnego doda ciasteczka dla każdego serwisu (najlepiej je trzymać w localStorage) i będzie to wyglądało w:
        //Ciastko 1 : serwis1
        //Ciastko 2 : serwis2
        // .......
        //
        // a sam NetAuthService można zaimplementować przez dependencyInjection do mikroserwisów - to co jest tutaj zrobione jest wyłącznie w celu demnostracji

        [HttpGet]
        public async Task<IActionResult> AuthenticateByToken(Guid token)
        {
            var claims = await mediator.Send(new AuthenticateByTokenQuery(token));
            //NetAuthService.AuthService auth = new AuthService(_context);
            //var user = auth.Login(token);
            //if (user != null)
            //{
            //    var claims = auth.GetClaims(user);
            var principal = new ClaimsPrincipal(claims.Claims);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok();

            return StatusCode(403);
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }


    //[HttpDelete]
    //public async Task<IActionResult> DeleteAccount()
    //{
    //    return Ok();
    //}
}

