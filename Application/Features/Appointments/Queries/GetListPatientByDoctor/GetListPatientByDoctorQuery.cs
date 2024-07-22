using Application.Repositories;
using Application.Services.Common;
using Application.Services.PatientService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appointments.Queries.GetListPatientByDoctor
{
    public class GetListPatientByDoctorQuery : PaginationParams, IRequest<PagedResponse<List<GetListPatientByDoctorResponse>>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Doctor"];

        public class GetListPatientByDoctorQueryHandler : IRequestHandler<GetListPatientByDoctorQuery, PagedResponse<List<GetListPatientByDoctorResponse>>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetListPatientByDoctorQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IHttpContextAccessor contextAccessor)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _httpContextAccessor = contextAccessor;
            }

            public async Task<PagedResponse<List<GetListPatientByDoctorResponse>>> Handle(GetListPatientByDoctorQuery request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                List<Appointment> appointments = await _appointmentRepository.GetListAsync(a => a.DoctorId == userId, include: a => a.Include(p => p.Patient), asNoTracking: true);

                IEnumerable<GetListPatientByDoctorResponse> query = appointments
                    .Select(a => a.Patient)
                    .GroupBy(p => p.Id)
                    .Select(g => g.First())
                    .Select(p => new GetListPatientByDoctorResponse
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        BloodType = p.BloodType.ConvertToString(),
                        EmergencyContact = p.EmergencyContact
                    });

                return query.ToPagedResponse(request);
            }
        }
    }
}
