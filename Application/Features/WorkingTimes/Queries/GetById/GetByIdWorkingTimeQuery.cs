using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.WorkingTimes.Queries.GetById
{
    public class GetByIdWorkingTimeQuery : IRequest<GetByIdWorkingTimeResponse>
    {
        public int Id { get; set; }

        public class GetByIdWorkingTimeQueryHandler : IRequestHandler<GetByIdWorkingTimeQuery, GetByIdWorkingTimeResponse>
        {
            private readonly IWorkingTimeRepository _workingTimeRepository;
            private readonly IMapper _mapper;

            public GetByIdWorkingTimeQueryHandler(IWorkingTimeRepository workingTimeRepository, IMapper mapper)
            {
                _workingTimeRepository = workingTimeRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdWorkingTimeResponse> Handle(GetByIdWorkingTimeQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.WorkingTime? workingTime = await _workingTimeRepository.GetAsync(w => w.Id == request.Id);

                if (workingTime is null)
                    throw new Exception("Bu id'ye ait kayıt bulunamadı");

                GetByIdWorkingTimeResponse response = _mapper.Map<GetByIdWorkingTimeResponse>(workingTime);
                return response;
            }
        }
    }
}
