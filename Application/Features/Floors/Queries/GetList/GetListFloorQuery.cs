using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Queries.GetList
{
    public class GetListFloorQuery : IRequest<List<GetListFloorResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] RequiredRoles => ["Floor.Add", "Floor.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListFloorQuery, List<GetListFloorResponse>>
        {
            private readonly IFloorRepository _floorRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IFloorRepository floorRepository, IMapper mapper)
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
