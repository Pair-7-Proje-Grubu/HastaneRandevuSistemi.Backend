using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OfficeLocations.Queries.GetList
{
    public class GetListOfficeLocationQuery : IRequest<List<GetListOfficeLocationResponse>>,ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public class GetListOfficeLocationQueryHandler : IRequestHandler<GetListOfficeLocationQuery, List<GetListOfficeLocationResponse>>
        {
            private readonly IOfficeLocationRepository _officeLocationRepository;
            private readonly IMapper _mapper;

            public GetListOfficeLocationQueryHandler(IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListOfficeLocationResponse>> Handle(GetListOfficeLocationQuery request, CancellationToken cancellationToken)
            {
                List<OfficeLocation> officeLocations = await _officeLocationRepository
                     .GetListAsync(include: query => query
                         .Include(ol => ol.Block)
                         .Include(ol => ol.Floor)
                         .Include(ol => ol.Room));

                // Map işlemi
                List<GetListOfficeLocationResponse> response = officeLocations.Select(ol => new GetListOfficeLocationResponse
                {
                    Id = ol.Id,
                    BlockNo = ol.Block.No,
                    FloorNo = ol.Floor.No,
                    RoomNo = ol.Room.No,
                    BlockId = ol.BlockId,
                    FloorId = ol.FloorId,
                    RoomId = ol.RoomId
                }).ToList();

                return response;
            }
        }
    }
}
