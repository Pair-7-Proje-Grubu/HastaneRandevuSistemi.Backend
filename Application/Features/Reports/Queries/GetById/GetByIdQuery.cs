using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdReportResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdReportResponse>
        {
            private IReportRepository _reportRepository;
            private IMapper _mapper;

            public GetByIdQueryHandler(IReportRepository reportRepository, IMapper mapper)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdReportResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Report? report = await _reportRepository.GetAsync(r => r.Id == request.Id);

                if (report is null)
                    throw new Exception("Böyle bir rapor bulunamadı.");

                GetByIdReportResponse response = _mapper.Map<GetByIdReportResponse>(report);

                return response;
            }
        }
    }
}
