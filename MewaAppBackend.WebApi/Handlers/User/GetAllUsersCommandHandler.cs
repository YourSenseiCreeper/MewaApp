using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.User;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.User;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.User
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Model.Model.User>().GetAllIncluding(u => u.Groups, u => u.Links).ToListAsync();
            var dto = _mapper.Map<IEnumerable<UserDto>>(data);
            return dto;
        }
    }
}
