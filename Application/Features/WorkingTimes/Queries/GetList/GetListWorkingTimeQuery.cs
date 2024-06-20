using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkingTimes.Queries.GetList
{
    public class GetListWorkingTimeQuery : IRequest<List<GetListWorkingTimeResponse>>
    {
        public int Page {  get; set; }
        public int PageSize { get; set; }

        public class GetListWorkingTimeQueryHandler : IRequestHandler<GetListWorkingTimeQuery, List<GetListWorkingTimeResponse>>
        {
            private readonly IWorkingTimeRepository _workingTimeRepository;
            private readonly IMapper _mapper;

            public GetListWorkingTimeQueryHandler(IWorkingTimeRepository workingTimeRepository, IMapper mapper)
            {
                _workingTimeRepository = workingTimeRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListWorkingTimeResponse>> Handle(GetListWorkingTimeQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.WorkingTime>? workingTimes = await _workingTimeRepository.GetListAsync();
                List<GetListWorkingTimeResponse> response = _mapper.Map<List<GetListWorkingTimeResponse>>(workingTimes);
                return response;
            }
        }
    }
}
