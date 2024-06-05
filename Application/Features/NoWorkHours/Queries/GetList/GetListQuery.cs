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
    public class GetListQuery : IRequest<List<GetAllNoWorkHourResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }


        public string[] RequiredRoles => ["NoWorkHour.Add", "NoWorkHour.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetAllNoWorkHourResponse>>
        {
            private readonly INoWorkHourRepository _noWorkHourRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(INoWorkHourRepository noWorkHourRepository, IMapper mapper)
            {
                _noWorkHourRepository = noWorkHourRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllNoWorkHourResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<NoWorkHour> noWorkHours = await _noWorkHourRepository.GetAllAsync();

                List<GetAllNoWorkHourResponse> response = _mapper.Map<List<GetAllNoWorkHourResponse>>(noWorkHours);

                return response;
            }
        }
    }
}
