﻿using MediatR;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class UpdateGroupCommand : IRequest
    {
        public int Id { get; set; }
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public IEnumerable<Entity> Links { get; set; }
        public IEnumerable<Entity> Tags { get; set; }
        public IEnumerable<Entity> Users { get; set; }
    }
}
