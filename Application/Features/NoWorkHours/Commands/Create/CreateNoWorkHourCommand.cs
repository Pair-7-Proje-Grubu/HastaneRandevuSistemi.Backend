using Application.Features.NoWorkHours.Dtos;
using Application.Repositories;
using AutoMapper;
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
        public List<NoWorkHourDto> NoWorkHours { get; set; }

        public class CreateNoWorkHourCommandHandler : IRequestHandler<CreateNoWorkHourCommand, CreateNoWorkHourResponse>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CreateNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;

            }
    
            public async Task<CreateNoWorkHourResponse> Handle(CreateNoWorkHourCommand request, CancellationToken cancellationToken)
            {
               string userId = _httpContextAccessor.HttpContext.User.Claims.Single(i => i.Type == ClaimTypes.NameIdentifier).Value;

                

                List<NoWorkHour> noWorkHours = _mapper.Map<List<NoWorkHour>>(request.NoWorkHours);


                await _noWorkHourRepository.AddRangeAsync(noWorkHours);
                var response = _mapper.Map<CreateNoWorkHourResponse>(noWorkHours);

                return response;
            }
        }
    }
}
