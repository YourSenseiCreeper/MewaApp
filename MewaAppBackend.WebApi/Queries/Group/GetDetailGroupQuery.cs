using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Queries.Group
{
    public class GetDetailGroupQuery : IRequest<ActionResult<GroupDto>>
    {
        public int Id { get; set; }
    }
}
