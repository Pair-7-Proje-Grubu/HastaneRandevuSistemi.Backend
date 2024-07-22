using Application.Features.NoWorkHours.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.NoWorkHours.Commands.Create
{
    public class CreateNoWorkHourCommand : IRequest<CreateNoWorkHourResponse>, ISecuredRequest
    {
        public List<NoWorkHourDto> NoWorkHours { get; set; }

        public string[] RequiredRoles { get; } = { "Doctor" };

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
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                List<NoWorkHour> noWorkHours = _mapper.Map<List<NoWorkHour>>(request.NoWorkHours);
                foreach (var noWorkHour in noWorkHours)
                {
                    noWorkHour.StartDate = noWorkHour.StartDate.ToLocalTime();
                    noWorkHour.EndDate = noWorkHour.EndDate.ToLocalTime();
                }

                await _noWorkHourRepository.AddRangeAsync(noWorkHours);

                List<DoctorNoWorkHour> doctorNoWorkHours = new() { };
                foreach (var noWorkHour in noWorkHours)
                {
                    DoctorNoWorkHour doctorNoWorkHour = new() { DoctorId = userId, NoWorkHourId = noWorkHour.Id };
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
