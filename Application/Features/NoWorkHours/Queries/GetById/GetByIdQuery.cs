using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.NoWorkHours.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdNoWorkHourResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdNoWorkHourResponse>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdNoWorkHourResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                NoWorkHour? noWorkHour = await _noWorkHourRepository.GetAsync(nwh => nwh.Id == request.Id);

                if (noWorkHour is null)
                    throw new Exception("Böyle bir veri bulunamadı.");

                GetByIdNoWorkHourResponse response = _mapper.Map<GetByIdNoWorkHourResponse>(noWorkHour);

                return response;
            }
        }
    }
}
