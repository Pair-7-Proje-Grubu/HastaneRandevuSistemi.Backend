using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Create
{
    public class CreateNoWorkHourCommand : IRequest<CreateNoWorkHourResponse>
    {
        public DateTime DateTime { get; set; }

        public class CreateNoWorkHourCommandHandler : IRequestHandler<CreateNoWorkHourCommand, CreateNoWorkHourResponse>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public CreateNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper) 
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task<CreateNoWorkHourResponse> Handle(CreateNoWorkHourCommand request, CancellationToken cancellationToken)
            {
                NoWorkHour noWorkHour = _mapper.Map<NoWorkHour>(request);

                await _noWorkHourRepository.AddAsync(noWorkHour);

                return new CreateNoWorkHourResponse() { Id = noWorkHour.Id, DateTime = noWorkHour.DateTime };
            }
        }
    }
}
