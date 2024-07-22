using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Floors.Queries.GetList
{
    public class GetListFloorQuery : IRequest<List<GetListFloorResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public class GetListFloorQueryHandler : IRequestHandler<GetListFloorQuery, List<GetListFloorResponse>>
        {

            private readonly IFloorRepository _floorRepository;
            private readonly IMapper _mapper;

            public GetListFloorQueryHandler(IFloorRepository floorRepository, IMapper mapper)
            {
                _floorRepository = floorRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListFloorResponse>> Handle(GetListFloorQuery request, CancellationToken cancellationToken)
            {
                List<Floor> floors = await _floorRepository.GetListAsync();

                List<GetListFloorResponse> response = _mapper.Map<List<GetListFloorResponse>>(floors);

                return response;
            }
        }
    }
}
