using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Application.Services.PatientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListPastAppointmentByDoctor
{
    public class GetListPastAppointmentByDoctorQuery : IRequest<List<GetListPastAppointmentByDoctorResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Doctor"];

        public class GetListPastAppointmentByDoctorQueryHandler : IRequestHandler<GetListPastAppointmentByDoctorQuery, List<GetListPastAppointmentByDoctorResponse>>
        {
            private readonly IAppointmentRepository _appointmentsRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetListPastAppointmentByDoctorQueryHandler(IAppointmentRepository appointmentsRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _appointmentsRepository = appointmentsRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<List<GetListPastAppointmentByDoctorResponse>> Handle(GetListPastAppointmentByDoctorQuery request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                List<Appointment> pastAppointments = (await _appointmentsRepository.GetListAsync(a => a.DoctorId == userId, include: p => p.Include(a => a.Patient))).Where(a => a.DateTime < DateTime.Now).ToList();

                List<GetListPastAppointmentByDoctorResponse> response = pastAppointments.Select(a => new GetListPastAppointmentByDoctorResponse
                {
                    FirstName = a.Patient.FirstName,
                    LastName = a.Patient.LastName,
                    AppointmentDate = a.DateTime.ToString(),
                }).ToList();
                return response;
            }
        }
    }
}
