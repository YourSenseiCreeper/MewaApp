﻿using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Tag;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTagByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();
            var data = repository.GetDetail(t => t.Id == request.Id);
            var dto = _mapper.Map<TagDto>(data);
            return dto;
        }
    }
}
