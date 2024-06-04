using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Update
{
    public class UpdateNoWorkHourCommand : IRequest<UpdateNoWorkHourResponse>
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public class UpdateNoWorkHourCommandHandler : IRequestHandler<UpdateNoWorkHourCommand, UpdateNoWorkHourResponse>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public UpdateNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task<UpdateNoWorkHourResponse> Handle(UpdateNoWorkHourCommand request, CancellationToken cancellationToken)
            { 
                NoWorkHour noWorkHour = _mapper.Map<NoWorkHour>(request);

                await _noWorkHourRepository.UpdateAsync(noWorkHour);

                UpdateNoWorkHourResponse response = _mapper.Map<UpdateNoWorkHourResponse>(noWorkHour);

                return response;
            }
        }
    }
}
