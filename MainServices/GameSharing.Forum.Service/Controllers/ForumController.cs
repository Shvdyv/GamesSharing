using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameSharing.Forum.Service.Application.Queries.DisplayPosts;
using GameSharing.Forum.Service.Application.Commands.AddPost;
using GameSharing.Forum.Service.Application.Commands.DeletePost;
using Microsoft.AspNetCore.Authorization;

namespace GameSharing.Forum.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ForumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] AddPostRepresantation addPostRepresantation)
        {
            await _mediator.Send(new AddPostCommand(addPostRepresantation.Author, addPostRepresantation.Content));
            return Ok();
        }
        //[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> DisplayPosts()
        {
            var result = await _mediator.Send(new DisplayPostsQuery());
            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return Ok();
        }
    }
}
