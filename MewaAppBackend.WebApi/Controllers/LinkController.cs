using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Link;
using MewaAppBackend.WebApi.Extentions;
using MewaAppBackend.WebApi.Handlers.Link;
using MewaAppBackend.WebApi.Queries;
using MewaAppBackend.WebApi.Queries.Link;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// All links without thumbnails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetAllLinks()
        {
            var request = new GetAllLinksQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetByUser")]
        public async Task<ActionResult<IEnumerable<Link>>> GetUserLinks(string? userName = null)
        {
            var userId = this.GetUserGuidFromRequest();
            return new OkObjectResult(await _mediator.Send(new GetUserLinksQuery { UserId = userId, UserName = userName }));
        }

        [HttpGet("GetLinkById")]
        public async Task<LinkDto> GetLinkById(int id)
        {
            return await _mediator.Send(new GetLinkByIdQuery { Id = id });
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddLink([FromBody] AddLinkDto dto)
        {
            var command = new AddLinkCommand
            {
                Url = dto.Url,
                Name = dto.Name,
                Description = dto.Description,
                Tags = dto.Tags,
                Groups = dto.Groups
            };
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLinkCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditLinkCommand dto)
        {
            return await _mediator.Send(dto);
        }
    }
}
