using Application.Repositories;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListAppointmentByAdmin
{
    public class GetListAppointmentByAdminQuery : PaginationParams, IRequest<PagedResponse<List<GetListAppointmentByAdminResponse>>>
    {
        public class GetListAppointmentByAdminQueryHandler : IRequestHandler<GetListAppointmentByAdminQuery, PagedResponse<List<GetListAppointmentByAdminResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IAppointmentRepository _appointmentRepository;

            public GetListAppointmentByAdminQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
            }

            public async Task<PagedResponse<List<GetListAppointmentByAdminResponse>>> Handle(GetListAppointmentByAdminQuery request, CancellationToken cancellationToken)
            {
                List<Appointment> appointments = await _appointmentRepository.GetListAsync(include:
                    a => a.Include(p => p.Patient)
                    .Include(d => d.Doctor.Clinic)
                    .Include(d => d.Doctor.User));

                IEnumerable<GetListAppointmentByAdminResponse> query = appointments.Select(a => new GetListAppointmentByAdminResponse
                {
                    Id = a.Id,
                    PatientName = a.Patient.FirstName + ' ' + a.Patient.LastName,
                    DoctorName = a.Doctor.User.FirstName + ' ' + a.Doctor.User.LastName,
                    ClinicName = a.Doctor.Clinic.Name,  
                    DateTime = a.DateTime,
                    Status = a.Status,
                });

                return query.ToPagedResponse(request);
            }
        }
    }
}
