using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Commands.Delete
{
    public class DeleteReportCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
        {
            private IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public DeleteReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteReportCommand request, CancellationToken cancellationToken)
            {
                Report? report = _mapper.Map<Report>(request);

                if (report is null)
                    throw new Exception("Rapor bulunamadı.");

                await _reportRepository.DeleteAsync(report);
            }
        }
    }
}
