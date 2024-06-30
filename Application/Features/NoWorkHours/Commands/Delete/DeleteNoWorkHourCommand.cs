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
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public DeleteNoWorkHourCommandHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteNoWorkHourCommand request, CancellationToken cancellationToken)
            {
                //if (request.Ids == null || !request.Ids.Any())
                //    throw new Exception("ID listesi boş olamaz.");

                //List<NoWorkHour>? noWorkHours = await _noWorkHourRepository.GetListAsync(h => request.Ids.Contains(h.Id));

                //if (noWorkHours == null || !noWorkHours.Any())
                //    throw new Exception("Veri bulunamadı.");

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
