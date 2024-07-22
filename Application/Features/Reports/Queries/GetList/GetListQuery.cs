using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetListReportResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] RequiredRoles => ["Report.Add", "Report.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetListReportResponse>>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IReportRepository reportRepository, IMapper mapper)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListReportResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<Report> reports = await _reportRepository.GetListAsync();

                List<GetListReportResponse> response = _mapper.Map<List<GetListReportResponse>>(reports);

                return response;
            }
        }
    }
}
