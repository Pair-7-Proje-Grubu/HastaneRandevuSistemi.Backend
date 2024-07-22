using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Commands.Update
{
    public class UpdateReportCommand : IRequest<UpdateReportResponse>
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public string Description { get; set; }

        public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, UpdateReportResponse>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public UpdateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
            }

            public async Task<UpdateReportResponse> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
            {
                // TODO: Kontroller eklenme durumu için gözat.

                Report report = _mapper.Map<Report>(request);

                await _reportRepository.UpdateAsync(report);

                UpdateReportResponse response = _mapper.Map<UpdateReportResponse>(report);

                return response;
            }
        }
    }
}
