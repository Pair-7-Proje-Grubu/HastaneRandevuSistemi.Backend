using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public string[] RequiredRoles => [ "Appointment.Doctor.Get" ];

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
                List<Appointment> activeAppointments = new List<Appointment>();

                int userId = Convert.ToInt16(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                activeAppointments = (await _appointmentRepository.GetListAsync(a => a.DoctorId == userId)).Where(a => a.DateTime > DateTime.Now).ToList();
                
                List<GetListActiveAppointmentByDoctorResponse> response = _mapper.Map<List<GetListActiveAppointmentByDoctorResponse>>(activeAppointments);
                return response;
            }
        }
    }
}
