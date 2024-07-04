using Application.Features.Doctors.Queries.GetListDoctor;
using Application.Repositories;
using AutoMapper;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListAppointment
{

    public class GetListAppointmentQuery : IRequest<List<GetListAppointmentResponse>>
    {
        public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, List<GetListAppointmentResponse>>
        {

            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public GetListAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IHttpContextAccessor contextAccessor)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _httpContextAccessor = contextAccessor;
            }


            public async Task<List<GetListAppointmentResponse>> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
            {

                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                List<Appointment> activeAppointments = (await _appointmentRepository.GetListAsync(a => a.PatientId == userId && a.DateTime > DateTime.Now,
                    include: a => a.Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Include(u => u.Doctor).ThenInclude(d => d.Clinic)
                    .Include(a => a.Doctor).ThenInclude(d => d.OfficeLocation).ThenInclude(u => u.Block)
                    .Include(a => a.Doctor).ThenInclude(d => d.OfficeLocation).ThenInclude(o => o.Floor)    
                    .Include(a => a.Doctor).ThenInclude(d => d.OfficeLocation).ThenInclude(u => u.Room)
                    )).OrderByDescending(a=> a.DateTime).ToList();

                List<GetListAppointmentResponse> response = activeAppointments.Select(a => new GetListAppointmentResponse
                {
                    DateTime = a.DateTime,
                    Doctor = a.Doctor.User.FirstName + " " + a.Doctor.User.LastName,
                    Clinic = a.Doctor.Clinic.Name,
                    CancelStatus = a.isCancelStatus,
                    OfficeLocation = $"Blok: '{a.Doctor.OfficeLocation.Block.No}', Kat: '{a.Doctor.OfficeLocation.Floor.No}', Oda: '{a.Doctor.OfficeLocation.Room.No}'"
                    
                }).ToList();

                
                return response;
            }
        }
    }
}
