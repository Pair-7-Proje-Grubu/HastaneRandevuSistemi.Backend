using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.NoWorkHours.Commands.Delete
{
    public class DeleteNoWorkHourCommand : IRequest, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Doctor"];

        public class DeleteNoWorkHourCommandHandler : IRequestHandler<DeleteNoWorkHourCommand>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public DeleteNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteNoWorkHourCommand request, CancellationToken cancellationToken)
            {

                NoWorkHour? noWorkHour = await _noWorkHourRepository.GetAsync(h => h.Id == request.Id);
                if (noWorkHour is null)
                {
                    throw new Exception("Id'ye ait veri bulunamadı");
                }

                await _noWorkHourRepository.DeleteAsync(noWorkHour);
            }
        }
    }
}
