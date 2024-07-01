using Application.Features.NoWorkHours.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Create
{
    public class CreateNoWorkHourCommand : IRequest<CreateNoWorkHourResponse>
    {
        public int DoctorId { get; set; }
        public List<NoWorkHourDto> NoWorkHours { get; set; }

        //string[] ISecuredRequest.RequiredRoles => RequiredRoles;

        //public string[] RequiredRoles { get; } = { "Doctor" };

        public class CreateNoWorkHourCommandHandler : IRequestHandler<CreateNoWorkHourCommand, CreateNoWorkHourResponse>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IDoctorNoWorkHourRepository _doctorNoWorkHourRepository;

            public CreateNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IDoctorNoWorkHourRepository doctorNoWorkHourRepository , IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _doctorNoWorkHourRepository = doctorNoWorkHourRepository;
            }
    
            public async Task<CreateNoWorkHourResponse> Handle(CreateNoWorkHourCommand request, CancellationToken cancellationToken)
            {

                List<NoWorkHour> noWorkHours = _mapper.Map<List<NoWorkHour>>(request.NoWorkHours);
                foreach (var noWorkHour in noWorkHours)
                {
                    noWorkHour.StartDate = noWorkHour.StartDate.ToLocalTime();
                    noWorkHour.EndDate = noWorkHour.EndDate.ToLocalTime();
                }

                await _noWorkHourRepository.AddRangeAsync(noWorkHours);

                List<DoctorNoWorkHour> doctorNoWorkHours = new List<DoctorNoWorkHour> { };
                foreach (var noWorkHour in noWorkHours)
                {
                    DoctorNoWorkHour doctorNoWorkHour = new DoctorNoWorkHour() { DoctorId = request.DoctorId, NoWorkHourId = noWorkHour.Id };
                    doctorNoWorkHours.Add(doctorNoWorkHour);
                }
                await _doctorNoWorkHourRepository.AddRangeAsync(doctorNoWorkHours);

                var response = new CreateNoWorkHourResponse
                {
                    NoWorkHours = _mapper.Map<List<NoWorkHourDto>>(noWorkHours)
                };

                return response;
            }
        }
    }
}
