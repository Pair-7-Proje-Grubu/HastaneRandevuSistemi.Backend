using Application.Repositories;
using Application.Services.Common;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appointments.Queries.GetListAppointment
{

    public class GetListAppointmentQuery : PaginationParams, IRequest<PagedResponse<List<GetListAppointmentResponse>>>
    {
        public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, PagedResponse<List<GetListAppointmentResponse>>>
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

            public string[] RequiredRoles => ["Patient"];


            public async Task<PagedResponse<List<GetListAppointmentResponse>>> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
            {

                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                List<Appointment> allAppointments = (await _appointmentRepository.GetListAsync(a => a.PatientId == userId,
                    include: a => a.Include(a => a.Doctor).ThenInclude(d => d.User)
                    .Include(u => u.Doctor).ThenInclude(d => d.Clinic)
                    .Include(a => a.Doctor).ThenInclude(d => d.OfficeLocation).ThenInclude(u => u.Block)
                    .Include(a => a.Doctor).ThenInclude(d => d.OfficeLocation).ThenInclude(o => o.Floor)
                    .Include(a => a.Doctor).ThenInclude(d => d.OfficeLocation).ThenInclude(u => u.Room)
                    ));

                IEnumerable<GetListAppointmentResponse> query = allAppointments
                .OrderBy(a => a.DateTime > DateTime.Now ? 0 : 1)
                .ThenBy(a => a.Status != AppointmentStatus.Scheduled ? 1 : 0)
                .ThenBy(a => a.DateTime > DateTime.Now ? a.DateTime : DateTime.MaxValue)
                .ThenByDescending(a => a.DateTime <= DateTime.Now ? a.DateTime : DateTime.MinValue)
                .Select(a => _mapper.Map<GetListAppointmentResponse>(a));

                return query.ToPagedResponse(request);
            }
        }
    }
}
