using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Doctors.Queries.GetListDoctorOfficeLocation
{
    public class GetDoctorListQuery : IRequest<List<DoctorOfficeLocationListResponse>>
    {
        public class GetDoctorListQueryHandler : IRequestHandler<GetDoctorListQuery, List<DoctorOfficeLocationListResponse>>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetDoctorListQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<List<DoctorOfficeLocationListResponse>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
            {
                var doctors = await _doctorRepository.GetListAsync(
                   include: d => d.Include(d => d.User)
                                   .Include(d => d.OfficeLocation)
                                   .ThenInclude(o => o.Block)
                                   .Include(d => d.OfficeLocation)
                                   .ThenInclude(o => o.Floor)
                                   .Include(d => d.OfficeLocation)
                                   .ThenInclude(o => o.Room)
               );

                var response = doctors.Select(d => new DoctorOfficeLocationListResponse
                {
                    FullName = $"{d.User.FirstName} {d.User.LastName}",
                    BlockNo = d.OfficeLocation.Block?.No,
                    FloorNo = d.OfficeLocation.Floor?.No,
                    RoomNo = d.OfficeLocation.Room?.No,
                     BlockId = d.OfficeLocation.BlockId,
                    FloorId = d.OfficeLocation.FloorId,
                    RoomId = d.OfficeLocation.RoomId,
                    DoctorId= d.User.Id,
                }).ToList();

                return response;
            }
        }
    }
    }
