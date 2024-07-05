using Application.Repositories;
using Application.Services.PatientService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListActiveAppointment
{
    public class GetListActiveAppointmentByDoctorQuery : IRequest<List<GetListActiveAppointmentByDoctorResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => [ "Doctor" ];

        public class GetListActiveAppointmentByDoctorQueryHandler : IRequestHandler<GetListActiveAppointmentByDoctorQuery, List<GetListActiveAppointmentByDoctorResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public GetListActiveAppointmentByDoctorQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }
            public async Task<List<GetListActiveAppointmentByDoctorResponse>> Handle(GetListActiveAppointmentByDoctorQuery request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                List<Appointment> activeAppointments = (await _appointmentRepository.GetListAsync(a => a.DoctorId == userId, include: q => q.Include(a => a.Patient))).Where(a => a.DateTime > DateTime.Now).ToList();
                
                List<GetListActiveAppointmentByDoctorResponse> response = activeAppointments.Select(a => new GetListActiveAppointmentByDoctorResponse
                {
                    FirstName = a.Patient.FirstName,
                    LastName = a.Patient.LastName,
                    AppointmentDate = a.DateTime
                }).ToList();

                return response;
            }
        }
    }
}
