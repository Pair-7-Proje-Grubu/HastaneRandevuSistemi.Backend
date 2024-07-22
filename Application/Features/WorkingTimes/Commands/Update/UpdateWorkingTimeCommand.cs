using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.WorkingTimes.Commands.Update
{
    public class UpdateWorkingTimeCommand : IRequest<UpdateWorkingTimeResponse>
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan EndBreakTime { get; set; }

        public class UpdateWorkingTimeCommandHandler : IRequestHandler<UpdateWorkingTimeCommand, UpdateWorkingTimeResponse>
        {
            private readonly IWorkingTimeRepository _workingTimeRepository;
            private readonly IMapper _mapper;

            public UpdateWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository, IMapper mapper)
            {
                _workingTimeRepository = workingTimeRepository;
                _mapper = mapper;
            }

            public async Task<UpdateWorkingTimeResponse> Handle(UpdateWorkingTimeCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.WorkingTime? workingTime = await _workingTimeRepository.GetAsync(w => w.Id == request.Id);
                
                if (workingTime is null)
                {
                    throw new Exception("Bu id'ye ait çalışma saati bulunamadı");
                }

                Domain.Entities.WorkingTime? mappedWorkingTime = _mapper.Map<Domain.Entities.WorkingTime>(request);

                await _workingTimeRepository.UpdateAsync(mappedWorkingTime);

                UpdateWorkingTimeResponse response = _mapper.Map<UpdateWorkingTimeResponse>(mappedWorkingTime);

                return response;
            }
        }
    }
}
