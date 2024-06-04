using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Delete
{
    public class DeleteNoWorkHourCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteNoWorkHourCommandHandler : IRequestHandler<DeleteNoWorkHourCommand>
        {
            private INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public DeleteNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteNoWorkHourCommand request, CancellationToken cancellationToken)
            {
                NoWorkHour? noWorkHour = _mapper.Map<NoWorkHour>(request);

                if (noWorkHour is null)
                    throw new Exception("Veri bulunamadı.");

                await _noWorkHourRepository.DeleteAsync(noWorkHour);
            }
        }
    }
}
