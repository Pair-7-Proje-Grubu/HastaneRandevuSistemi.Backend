using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Queries.GetById
{
    public class GetByIdFloorQuery : IRequest<GetByIdFloorResponse>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class GetByIdQueryHandler : IRequestHandler<GetByIdFloorQuery, GetByIdFloorResponse>
        {
            private IFloorRepository _floorRepository;
            private IMapper _mapper;

            public GetByIdQueryHandler(IFloorRepository floorRepository, IMapper mapper)
            {
                _floorRepository = floorRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdFloorResponse> Handle(GetByIdFloorQuery request, CancellationToken cancellationToken)
            {
                Floor? floor = await _floorRepository.GetAsync(r => r.Id == request.Id);

                if (floor is null)
                    throw new Exception("Böyle bir veri bulunamadı.");

                GetByIdFloorResponse response = _mapper.Map<GetByIdFloorResponse>(floor);

                return response;
            }
        }
    }
}
