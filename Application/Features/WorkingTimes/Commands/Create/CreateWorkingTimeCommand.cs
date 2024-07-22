using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.WorkingTimes.Commands.Create
{
    public class CreateWorkingTimeCommand : IRequest<CreateWorkingTimeResponse>
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
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
