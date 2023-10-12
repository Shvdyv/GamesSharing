using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using GameSharing.Account.Service.Application.Commands.Login;

namespace GameSharing.Account.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private bool ValidateLogin(string userName, string password)
        {
            return true;
        }

        private string DetermineUserRole(string userName)
        {
            if (userName == "admin")
            {
                return "admin";
            }
            else
            {
                return "user";
            }
        }

        [HttpPost] // get ... from body
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            //ViewData["ReturnUrl"] = returnUrl;

            if (ValidateLogin(userName, password))
            {
                var role = DetermineUserRole(userName);
                var claims = new List<Claim>
                {
                    new Claim("user", userName),
                    new Claim(nameof(role), role)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }



        //[HttpPost]
        //public async Task<IActionResult> Register()
        //{
        //    return Ok();
        //}


        //[HttpPut]
        //public async Task<IActionResult> EditAccount()
        //{
        //    return Ok();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAccount()
        //{
        //    return Ok();
        //}
    }
}
