using Application.Repositories;
using MediatR;

namespace Application.Features.WorkingTimes.Commands.Delete
{
    public class DeleteWorkingTimeCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteWorkingTimeCommandHandler : IRequestHandler<DeleteWorkingTimeCommand>
        {
            private readonly IWorkingTimeRepository _workingTimeRepository;

            public DeleteWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository)
            {
                _workingTimeRepository = workingTimeRepository;
            }

            public async Task Handle(DeleteWorkingTimeCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.WorkingTime? workingTime = await _workingTimeRepository.GetAsync(w => w.Id ==  request.Id);

                if (workingTime is null)
                    throw new Exception("Bu id'ye ait bir çalışma saati bulunmamaktadır");

                await _workingTimeRepository.DeleteAsync(workingTime);
            }
        }
    }
}
