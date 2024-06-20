using Application.Features.WorkingTimes.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Converters;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.WorkingTimes.Commands.Create
{
    public class CreateWorkingTimeCommand : IRequest<CreateWorkingTimeResponse>
    {
        [JsonConverter(typeof(TimeSpanToStringConverter))]
        public TimeSpan StartTime { get; set; }
        [JsonConverter(typeof(TimeSpanToStringConverter))]
        public TimeSpan EndTime { get; set; }
        [JsonConverter(typeof(TimeSpanToStringConverter))]
        public TimeSpan StartBreakTime { get; set; }
        [JsonConverter(typeof(TimeSpanToStringConverter))]
        public TimeSpan EndBreakTime { get; set; }

        public class CreateWorkingTimeCommandHandler : IRequestHandler<CreateWorkingTimeCommand, CreateWorkingTimeResponse>
        {
            private readonly IWorkingTimeRepository _workingTimeRepository;
            private readonly IMapper _mapper;

            public CreateWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository, IMapper mapper)
            {
                _workingTimeRepository = workingTimeRepository;
                _mapper = mapper;
            }

            public async Task<CreateWorkingTimeResponse> Handle(CreateWorkingTimeCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.WorkingTime workingTime = _mapper.Map<Domain.Entities.WorkingTime>(request);
                await _workingTimeRepository.AddAsync(workingTime);

                CreateWorkingTimeResponse response = _mapper.Map<CreateWorkingTimeResponse>(workingTime);
                return response;
            }
        }
    }
}
