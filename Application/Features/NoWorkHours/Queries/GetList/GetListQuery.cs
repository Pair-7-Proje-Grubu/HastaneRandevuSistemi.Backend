using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetListNoWorkHourResponse>>, ISecuredRequest
    {
        //public int Page { get; set; }
        //public int PageSize { get; set; }
        public int? DoctorId { get; set; }
        string[] ISecuredRequest.RequiredRoles => RequiredRoles;
        public string[] RequiredRoles { get; } = { "Doctor", "Admin" };

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetListNoWorkHourResponse>>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IDoctorNoWorkHourRepository _doctorNoWorkHourRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper, IDoctorNoWorkHourRepository doctorNoWorkHourRepository)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
                _doctorNoWorkHourRepository = doctorNoWorkHourRepository;
            }

            public async Task<List<GetListNoWorkHourResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<NoWorkHour> noWorkHours = new List<NoWorkHour>();

                if (request.DoctorId is null)
                {
                    noWorkHours = await _noWorkHourRepository.GetListAsync();
                }
                    
                else if(request.DoctorId.HasValue)
                { 
                    var doctorNoWorkHours = await _doctorNoWorkHourRepository.GetListAsync(h => h.DoctorId == request.DoctorId, include: h => h.Include(d => d.NoWorkHour));

                    noWorkHours = doctorNoWorkHours.Select(dnwh => dnwh.NoWorkHour).ToList();
                }

                List<GetListNoWorkHourResponse> response = _mapper.Map<List<GetListNoWorkHourResponse>>(noWorkHours);

                return response;
            }
        }
    }
}
