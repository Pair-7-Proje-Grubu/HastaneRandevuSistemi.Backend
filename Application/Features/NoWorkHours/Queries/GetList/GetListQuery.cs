using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetListNoWorkHourResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }


        public string[] RequiredRoles => ["NoWorkHour.Add", "NoWorkHour.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetListNoWorkHourResponse>>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListNoWorkHourResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<NoWorkHour> noWorkHours = await _noWorkHourRepository.GetListAsync();

                List<GetListNoWorkHourResponse> response = _mapper.Map<List<GetListNoWorkHourResponse>>(noWorkHours);

                return response;
            }
        }
    }
}
