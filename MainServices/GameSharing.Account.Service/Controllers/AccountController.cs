using Microsoft.AspNetCore.Mvc;
using MediatR;

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

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditAccount()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount()
        {
            return Ok();
        }
    }
}
