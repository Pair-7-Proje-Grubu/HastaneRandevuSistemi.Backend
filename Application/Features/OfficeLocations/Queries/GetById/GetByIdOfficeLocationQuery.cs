using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Queries.GetById
{
    public class GetByIdOfficeLocationQuery : IRequest<GetByIdOfficeLocationResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdOfficeLocationQuery, GetByIdOfficeLocationResponse>
        {
            private IOfficeLocationRepository _officeLocationRepository;
            private IMapper _mapper;

            public GetByIdQueryHandler(IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdOfficeLocationResponse> Handle(GetByIdOfficeLocationQuery request, CancellationToken cancellationToken)
            {
                OfficeLocation? officeLocation = await _officeLocationRepository.GetAsync(r => r.Id == request.Id);

                if (officeLocation is null)
                    throw new Exception("Böyle bir veri bulunamadı.");

                GetByIdOfficeLocationResponse response = _mapper.Map<GetByIdOfficeLocationResponse>(officeLocation);

                return response;
            }
        }
    }
}
