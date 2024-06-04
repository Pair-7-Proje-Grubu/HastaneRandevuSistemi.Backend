using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetAllReportResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] RequiredRoles => ["Report.Add", "Report.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetAllReportResponse>>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IReportRepository reportRepository, IMapper mapper)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllReportResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<Report> reports = await _reportRepository.GetAllAsync();

                List<GetAllReportResponse> response = _mapper.Map<List<GetAllReportResponse>>(reports);

                return response;
            }
        }
    }
}
