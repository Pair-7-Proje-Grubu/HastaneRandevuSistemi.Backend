using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Queries.GetList
{
    public class GetListOfficeLocationQuery : IRequest<List<GetListOfficeLocationResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] RequiredRoles => ["OfficeLocation.Add", "OfficeLocation.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListOfficeLocationQuery, List<GetListOfficeLocationResponse>>
        {
            private readonly IOfficeLocationRepository _officeLocationRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListOfficeLocationResponse>> Handle(GetListOfficeLocationQuery request, CancellationToken cancellationToken)
            {
                List<OfficeLocation> officeLocations = await _officeLocationRepository.GetListAsync();

                List<GetListOfficeLocationResponse> response = _mapper.Map<List<GetListOfficeLocationResponse>>(officeLocations);

                return response;
            }
        }
    }
}
