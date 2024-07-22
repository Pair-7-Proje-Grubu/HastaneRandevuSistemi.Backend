using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Commands.Create
{
    public class CreateReportCommand : IRequest<CreateReportResponse>
    {
        public int AppointmentId { get; set; }
        public string Description { get; set; }

        public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportResponse>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public CreateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
            }

            public async Task<CreateReportResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
            {
                // TODO: Kontroller eklenme durumu için gözat.
                Report report = _mapper.Map<Report>(request);
                await _reportRepository.AddAsync(report);
                return new CreateReportResponse { Id = report.Id, AppointmentId = report.AppointmentId, Description = report.Description };
            }
        }
    }
}
